using System;
using Light2D.Colors;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class HelloWorldScene : Scene
    {
        public HelloWorldScene() : base(ambient: RGBColor.FromRGB(0.15))
        {
            AddShape(new Circle(new Vector2(0), 0.15, RGBColor.White, RGBColor.White));

            int n = 6;
            float r = 0.5f;
            for(float i = 0; i < 6; i++)
            {
                var theta = 2.0 * Math.PI * i / n;
                (var x, var y) = (r * Math.Cos(theta), r * Math.Sin(theta));
                AddShape(new Circle(new Vector2(x, y), radius: 0.08, 
                    diffuse: RGBColor.FromRGB(0.5), emissive: RGBColor.Black)
                );
            }
        }
    }
}