using System;
using Light2D.Rendering;

namespace Light2D.Shapes
{
    public class Rectangle : Shape
    {
        public Vector2 Position { get; }
        public Vector2 Size { get; }

        public Rectangle(Vector2 position, Vector2 size, Material material) : base(material)
        {
            Position = position;
            Size = size;
        }

        public override double Distance(Vector2 u)
        {
            var d = Vector2.Abs(Position - u) - Size;
            return Vector2.Max(d, 0.0).Length() + Math.Min(Math.Max(d.X, d.Y), 0.0);
        }
    }
}