using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Light2D.Scenes;
using Light2D.Samplers;
using Light2D.Colors;
using Light2D.Debug;

namespace Light2D.Rendering
{
    public class Renderer
    {
        public Sampler Sampler { get; }
        private RenderStatus Status { get; set; }
        private Raymarcher Raymarcher { get; set; }
        private SceneDistanceBuffer SceneDistanceBuffer { get; set; }

        public Renderer(Sampler sampler)
        {
            this.Sampler = sampler;
        }

        public void Render(Camera camera, Scene scene, string outputFileName)
        {
            WriteRenderInfo(camera);
            // var nmd = new NormalMapDebugger(camera, scene);
            SceneDistanceBuffer = new SceneDistanceBuffer(camera, scene);
            SceneDistanceBuffer.SaveToFile();
            Status = new RenderStatus(camera.DevicePixelHeight);
            Raymarcher = new Raymarcher(scene, SceneDistanceBuffer);
            var nCores = Environment.ProcessorCount;
            var yLines = Enumerable.Range(0, camera.DevicePixelHeight).ToList();
            Parallel.ForEach(yLines, (y) => RenderRow(camera, scene, y));
            Console.WriteLine();
            camera.SaveToFile(outputFileName);
        }

        private void RenderRow(Camera camera, Scene scene, int y)
        {
            var sampler = Sampler.GetThreadSafeInstance();

            for (int x = 0; x < camera.DevicePixelWidth; x++)
            {
                RenderPixel(camera, scene, sampler, y, x);
            }

            Status.Increment();
        }

        private void RenderPixel(Camera camera, Scene scene, Sampler sampler, int y, int x)
        {
            var pixelSampleColor = RGBColor.Black;

            foreach(var pixelSampleOffset in sampler.NextPixelSampleOffset())
            {
                var uv = camera.GetUV(x + pixelSampleOffset.X, y + pixelSampleOffset.Y);
                var lightSampleColor = RGBColor.Black;

                foreach(var lightSampleDirection in sampler.NextLightSampleDirection())
                {
                    lightSampleColor += SampleLight(uv, scene, lightSampleDirection);
                }

                pixelSampleColor += 1.0 / sampler.LightSamples * lightSampleColor;
            }

            pixelSampleColor *= 1.0 / sampler.PixelSamples;
            camera.SetPixel(x, y, pixelSampleColor);
        }

        private RGBColor SampleLight(Vector2 uv, Scene scene, Vector2 lightSampleDirection, int maxRecursionDepth = 16)
        {
            var ray = new Ray(uv, lightSampleDirection);
            (var t, var shape) = Raymarcher.March(ray);
            if (t < Raymarcher.MinMarchDistance)
            {
                return shape.Material.DiffuseColor;
            }
            if (t < Raymarcher.MaxMarchDistance)
            {
                if(shape.Material.Reflectivity > 0 && maxRecursionDepth > 0)
                {
                    var p = ray.GetPoint(t);
                    var normal = scene.NormalAtPoint(p);
                    var reflectedRay = Vector2.Reflect(lightSampleDirection, normal);
                    var light = shape.Material.Intensity * shape.Material.EmissiveColor;
                    var reflected = SampleLight(p + 0.001 * reflectedRay, scene, reflectedRay, maxRecursionDepth - 1);
                    return  (1.0 - shape.Material.Reflectivity) * light + shape.Material.Reflectivity * reflected;
                }

                // TODO: Refraction

                return shape.Material.Intensity * shape.Material.EmissiveColor;
            }
            else if(t > Raymarcher.MaxMarchDistance)
            {
                return scene.AmbientColor;
            }
            return RGBColor.Black;
        }

        private void WriteRenderInfo(Camera camera)
        {
            Console.WriteLine($"Dimension: {camera.DevicePixelWidth}x{camera.DevicePixelHeight}");
            Console.WriteLine($"Pixel samples: {Sampler.PixelSamples}");
            Console.WriteLine($"Light samples: {Sampler.LightSamples}");
        }
    }
}