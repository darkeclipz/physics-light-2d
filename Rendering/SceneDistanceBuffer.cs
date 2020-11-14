using System;
using Light2D.Colors;
using Light2D.Scenes;

namespace Light2D.Rendering
{
    public class SceneDistanceBuffer
    {
        public Scene Scene { get; }
        public Camera Camera { get; }
        private double[,] Buffer { get; set; }
        public double PixelSize { get; set; }
        
        public SceneDistanceBuffer(Camera camera, Scene scene)
        {
            Camera = camera;
            Scene = scene;
            Buffer = new double[camera.DevicePixelWidth, camera.DevicePixelHeight];
            PixelSize = Math.Max(1.0 / camera.DevicePixelWidth, 1.0 / camera.DevicePixelHeight);
            Console.WriteLine("Generating scene distance buffer");
            CalculateBuffer();
        }

        private void CalculateBuffer()
        {
            for(int x = 0; x < Camera.DevicePixelWidth; x++)
            {
                for(int y = 0; y < Camera.DevicePixelHeight; y++)
                {
                    var p = Camera.GetUV(x + 0.5, y + 0.5);
                    (var t, var shape) = Scene.Distance(p);
                    Buffer[x, y] = t;
                }
            }
        }

        public double Distance(Vector2 uv)
        {
            var p = Camera.InverseUV(uv);
            return Buffer[
                Math.Clamp((int)p.X, 0, Camera.DevicePixelWidth - 1),
                Math.Clamp((int)p.Y, 0, Camera.DevicePixelHeight - 1)
            ];
        }

        public void SaveToFile()
        {
            var film = new Film(Camera.DevicePixelWidth, Camera.DevicePixelHeight);
            for(int x = 0; x < Camera.DevicePixelWidth; x++)
            {
                for(int y = 0; y < Camera.DevicePixelHeight; y++)
                {
                    var color = new RGBColor(Buffer[x, y]);
                    film.SetPixel(x, y, color);
                }
            }
            film.SaveToFile("images/sdb.png");
        }
    }
}