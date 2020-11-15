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
            AddShape(new Rectangle(new Vector2(0, 0), new Vector2(0.15), Materials.WhiteLight));
            //Shapes[0].Material.Intensity = 4.0;
            double d = 0.6;
            double r = 0.10;
            AddShape(new Circle(new Vector2(d, 0), r, Materials.Default));
            AddShape(new Circle(new Vector2(-d, 0), r, Materials.Default));
            AddShape(new Circle(new Vector2(0.0, d), r, Materials.Default));
            AddShape(new Circle(new Vector2(0.0, -d), r, Materials.Default));
        }
    }
}