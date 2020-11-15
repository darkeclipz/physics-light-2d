using System;
using Light2D.Colors;
using Light2D.Rendering;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class ReflectionScene : Scene
    {
        public ReflectionScene() : base(ambient: RGBColor.FromRGB(0.15))
        {
            AddShape(new Circle(new Vector2(0), 0.15, Materials.WhiteLight));

            int n = 6;
            float r = 0.5f;
            for(float i = 0; i < 6; i++)
            {
                var theta = 2.0 * Math.PI * i / n;
                (var x, var y) = (r * Math.Cos(theta), r * Math.Sin(theta));
                AddShape(new Circle(new Vector2(x, y), radius: 0.1, Materials.Mirror));
            }
        }
    }
}