using Light2D.Colors;

namespace Light2D.Rendering
{
    public class Camera
    {
        public int DevicePixelWidth { get; }
        public int DevicePixelHeight { get; }
        private Film Film { get; }

        public Camera(int devicePixelWidth, int devicePixelHeight)
        {
            this.DevicePixelHeight = devicePixelHeight;
            this.DevicePixelWidth = devicePixelWidth;
            this.Film = new Film(DevicePixelWidth, devicePixelHeight);
        }

        public Vector2 GetUV(double x, double y) => new Vector2(
            (2.0 * x - DevicePixelWidth) / DevicePixelHeight, 
            (2.0 * y - DevicePixelHeight) / DevicePixelHeight
        );

        public Vector2 InverseUV(Vector2 uv) => new Vector2(
            (uv.X * DevicePixelHeight + DevicePixelWidth) / 2,
            (uv.Y * DevicePixelHeight + DevicePixelHeight) / 2
        );
        
        public void SetPixel(int x, int y, RGBColor color) => Film.SetPixel(x, y, color);
        public void SaveToFile(string fileName) => Film.SaveToFile(fileName);
    }
}