using Light2D.Colors;
using Light2D.Rendering;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class MandelbrotScene : Scene
    {
        public MandelbrotScene() : base(ambient: RGBColor.FromRGB(0))
        {
            AddShape(new Mandelbrot(new Vector2(-0.5, 0), 2.0, Materials.WhiteLight));
        }
    }
}