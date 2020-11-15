using System;
using Light2D.Colors;
using Light2D.Rendering;
using Light2D.Scenes;

namespace Light2D.Debug
{
    public class NormalMapDebugger
    {
        public NormalMapDebugger(Camera camera, Scene scene)
        {
            Console.WriteLine("Rendering normal map");
            RenderNormalMap(camera, scene);
        }

        private void RenderNormalMap(Camera camera, Scene scene)
        {
            var film = new Film(camera.DevicePixelWidth, camera.DevicePixelHeight);
            for(int x = 0; x < camera.DevicePixelWidth; x++)
            {
                for(int y = 0; y < camera.DevicePixelHeight; y++)
                {
                    var uv = camera.GetUV(x, y);
                    var normal = scene.NormalAtPoint(uv);
                    film.SetPixel(x, y, RGBColor.FromRGB(normal.X, normal.Y, 0));
                }
            }
            film.SaveToFile("images/normal.png");
        }
    }
}