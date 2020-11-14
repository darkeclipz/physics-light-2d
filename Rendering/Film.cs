using System;
using System.Drawing;
using System.Drawing.Imaging;
using Light2D.Colors;

namespace Light2D.Rendering
{
    public class Film
    {
        private static int CHANNEL_R = 0;
        private static int CHANNEL_G = 1;
        private static int CHANNEL_B = 2;

        public int DevicePixelWidth { get; }
        public int DevicePixelHeight { get; }
        public double[,,] PixelData { get; }

        public Film(int devicePixelWidth, int devicePixelHeight)
        {
            this.DevicePixelHeight = devicePixelHeight;
            this.DevicePixelWidth = devicePixelWidth;
            this.PixelData = new double[devicePixelWidth, devicePixelHeight, 3];
        }

        public void SetPixel(int x, int y, RGBColor color)
        {
            PixelData[x, y, CHANNEL_R] = color.R;
            PixelData[x, y, CHANNEL_G] = color.G;
            PixelData[x, y, CHANNEL_B] = color.B;
        }

        public RGBColor GetPixel(int x, int y) 
        {
            var (r, g, b) = (PixelData[x, y, CHANNEL_R], PixelData[x, y, CHANNEL_G], PixelData[x, y, CHANNEL_B]);
            return new RGBColor(r, g, b);   
        }

        public void SaveToFile(string fileName)
        {
            var bitmap = new Bitmap(DevicePixelWidth, DevicePixelHeight);
            for(int y = 0; y < DevicePixelHeight; y++) 
            {
                for(int x = 0; x < DevicePixelWidth; x++)
                {
                    var (r, g, b) = (PixelData[x, DevicePixelHeight - y - 1, CHANNEL_R], 
                                     PixelData[x, DevicePixelHeight - y - 1, CHANNEL_G], 
                                     PixelData[x, DevicePixelHeight - y - 1, CHANNEL_B]);
                    var color = Color.FromArgb(
                        Math.Clamp((int)(255*r), 0, 255), 
                        Math.Clamp((int)(255*g), 0, 255), 
                        Math.Clamp((int)(255*b), 0, 255)
                    );
                    bitmap.SetPixel(x, y, color);
                }
            }
            bitmap.Save(fileName, ImageFormat.Png);
            bitmap.Dispose();
        }
    }
}
