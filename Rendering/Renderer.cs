using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Light2D.Scenes;
using Light2D.Samplers;
using Light2D.Colors;

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
                    lightSampleColor += SampleLight(uv, scene, lightSampleDirection) + scene.AmbientColor;
                }

                pixelSampleColor += 1.0 / sampler.LightSamples * lightSampleColor;
            }

            pixelSampleColor *= 1.0 / sampler.PixelSamples;
            camera.SetPixel(x, y, pixelSampleColor);
        }

        private RGBColor SampleLight(Vector2 uv, Scene scene, Vector2 lightSampleDirection)
        {
            var ray = new Ray(uv, lightSampleDirection);
            (var t, var shape) = Raymarcher.March(ray);
            if (t < Raymarcher.MaxMarchDistance)
            {
                return shape.EmissiveColor;
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