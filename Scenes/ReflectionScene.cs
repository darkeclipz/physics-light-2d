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
            var lightMaterial = Materials.WhiteLight;
            lightMaterial.Intensity = 2;
            AddShape(new Circle(new Vector2(-0.5, 0.5), 0.2, lightMaterial));

            var material = Materials.Default;
            AddShape(new Rectangle(new Vector2(-0.3, -0.5), new Vector2(0.2), material));
            AddShape(new Rectangle(new Vector2(0.5, -0.3), new Vector2(0.3), material));
        }
    }
}