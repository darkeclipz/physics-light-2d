using System;
using System.Diagnostics;
using Light2D.Rendering;
using Light2D.Samplers;
using Light2D.Scenes;

namespace Light2D
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var camera = new Camera(800, 800);
            Scene scene = new RGBScene();
            Sampler sampler = new StratifiedSampler(pixelSamples: 4, lightSamples: 32);
            var renderer = new Renderer(sampler);
            stopwatch.Start();
            renderer.Render(camera, scene, "images/rgb-scene.png");
            stopwatch.Stop();
            Console.WriteLine($"Total render time: {stopwatch.Elapsed}");
        }
    }
}
