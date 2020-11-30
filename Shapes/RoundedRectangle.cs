using System;
using Light2D.Rendering;

namespace Light2D.Shapes
{
    public class RoundedRectangle : Shape
    {
        public Vector2 Position { get; }
        public Vector2 Size { get; }
        public double Radius { get; }

        public RoundedRectangle(Vector2 position, Vector2 size, double radius, Material material) : base(material)
        {
            Position = position;
            Size = size;
            Radius = radius;
        }

        public override double Distance(Vector2 u)
        {
            var d = Vector2.Abs(Position - u) - Size - new Vector2(Radius);
            return Vector2.Max(d, 0.0).Length() + Math.Min(Math.Max(d.X, d.Y), 0.0) - Radius;
        }
    }
}