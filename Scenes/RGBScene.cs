using System;
using System.Collections.Generic;
using Light2D.Colors;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class RGBScene : Scene
    {
        public RGBScene() : base(ambient: RGBColor.FromRGB(0.15))
        {
            int n = 3;
            float r = 0.2f;
            var colors = new List<RGBColor>() { RGBColor.Red, RGBColor.Green, RGBColor.Blue };
            for(int i = 0; i < n; i++)
            {
                var theta = 2.0 * Math.PI * i / n + Math.PI / 2;
                (var x, var y) = (r * Math.Cos(theta), r * Math.Sin(theta));
                AddShape(new Circle(new Vector2(x, y), radius: 0.15, 
                    diffuse: RGBColor.FromRGB(0.5), emissive: 2 * colors[i])
                );
            }

            n = 12;
            r = 0.65f;
            for(int i = 0; i < n; i++)
            {
                var theta = 2.0 * Math.PI * i / n + Math.PI / 2;
                (var x, var y) = (r * Math.Cos(theta), r * Math.Sin(theta));
                AddShape(new Circle(new Vector2(x, y), radius: 0.025, 
                    diffuse: RGBColor.FromRGB(0.5), emissive: RGBColor.Black)
                );
            }
        }
    }
}