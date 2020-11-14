using System;
using System.Collections.Generic;

namespace Light2D.Samplers
{
    public class StratifiedSampler : Sampler
    {
        public StratifiedSampler(int pixelSamples, int lightSamples) : base(pixelSamples, lightSamples) { }

        public override IEnumerable<Vector2> NextLightSampleDirection()
        {
            double size = 2 * Math.PI / LightSamples;
            for(int i = 0; i < LightSamples; i++)
            {
                var theta = i * size + size * StaticRandom.Next();
                (var x, var y) = (Math.Cos(theta), Math.Sin(theta));
                yield return new Vector2(x, y);
            }
        }

        public override IEnumerable<Vector2> NextPixelSampleOffset()
        {
            double size = 1.0 / Math.Sqrt(PixelSamples);
            for(double x = 0; x < 1.0; x += size) 
            {
                for(double y = 0; y < 1.0; y += size)
                {
                    (var offsetX, var offsetY) = (size * StaticRandom.Next(), size * StaticRandom.Next());
                    yield return new Vector2(x + offsetX, y + offsetY);
                }
            }
        }

        public override Sampler GetThreadSafeInstance() => (StratifiedSampler)this.MemberwiseClone();
    }
}