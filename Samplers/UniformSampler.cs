using System;
using System.Collections.Generic;

namespace Light2D.Samplers
{
    public class UniformSampler : Sampler
    {
        public UniformSampler(int pixelSamples, int lightSamples) : base(pixelSamples, lightSamples) { }

        public override IEnumerable<Vector2> NextPixelSampleOffset()
        {
            for(int i = 0; i < PixelSamples; i++)
            {
                (var x, var y) = (StaticRandom.Next(), StaticRandom.Next());
                yield return new Vector2(x, y);
            }
        }

        public override IEnumerable<Vector2> NextLightSampleDirection()
        {
            for(int i = 0; i < LightSamples; i++)
            {
                var theta = 2 * Math.PI * StaticRandom.Next();
                (var x, var y) = (Math.Cos(theta), Math.Sin(theta));
                yield return new Vector2(x, y);
            }
        }

        public override Sampler GetThreadSafeInstance() => (UniformSampler)this.MemberwiseClone();
    }
}