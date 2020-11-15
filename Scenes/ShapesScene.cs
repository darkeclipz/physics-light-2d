using System;
using Light2D.Colors;
using Light2D.Rendering;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class ShapesScene : Scene
    {
        public ShapesScene() : base(ambient: RGBColor.FromRGB(0.15))
        {
            var circle = new Circle(new Vector2(-0.5, 0.5), 0.25, Materials.WhiteLight);
            AddShape(circle);

            var rectangle = new Rectangle(new Vector2(0.5, 0.5), new Vector2(0.25), Materials.WhiteLight);
            AddShape(rectangle);

            var triangle = new Triangle(new Vector2(-0.5, -0.5), 0.25, Materials.WhiteLight);
            AddShape(triangle);
        }
    }
}