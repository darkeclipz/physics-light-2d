using System;
using System.Collections.Generic;

namespace Light2D.Samplers
{
    public abstract class Sampler
    {
        public int PixelSamples { get; }
        public int LightSamples { get; }

        public Sampler(int pixelSamples, int lightSamples)
        {
            PixelSamples = pixelSamples;
            LightSamples = lightSamples;
        }

        public abstract IEnumerable<Vector2> NextPixelSampleOffset();
        public abstract IEnumerable<Vector2> NextLightSampleDirection();
        public abstract Sampler GetThreadSafeInstance();
    }

    public static class StaticRandom
    {
        private static Random RNG = new Random(Seed: 3895979);
        
        private static object randomLock = false;
        public static double Next()
        {
            lock(randomLock)
            {
                return RNG.NextDouble();
            }
        }
    }
}