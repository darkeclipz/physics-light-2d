using System;
using Light2D.Rendering;

namespace Light2D.Shapes
{
    public class Triangle : Shape
    {
        public Vector2 Position { get; }
        public double Size { get; }

        public Triangle(Vector2 position, double size, Material material) : base(material)
        {
            Position = position;
            Size = size;
        }

        public override double Distance(Vector2 u)
        {
            double k = Math.Sqrt(3.0);
            var p = Position.Copy() - u;
            p *= 1.0 / Size;
            p.X = Math.Abs(p.X) - 1.0;
            p.Y = p.Y + 1.0 / k;
            if(p.X + k * p.Y > 0.0)
            {
                p = 0.5 * new Vector2(p.X - k * p.Y, -k * p.X - p.Y);
            }
            p.X -= Math.Clamp(p.X, -2.0, 0.0);
            return (-p.Length() * Math.Sign(p.Y)) * Size;
        }
    }
}