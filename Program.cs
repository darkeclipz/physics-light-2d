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
            var camera = new Camera(500, 500);
            Scene scene = new MandelbrotScene();
            Sampler sampler = new StratifiedSampler(pixelSamples: 4, lightSamples: 32);
            var renderer = new Renderer(sampler);
            stopwatch.Start();
            renderer.Render(camera, scene, "images/mandelbrot.png");
            stopwatch.Stop();
            Console.WriteLine($"Total render time: {stopwatch.Elapsed}");
        }
    }
}
