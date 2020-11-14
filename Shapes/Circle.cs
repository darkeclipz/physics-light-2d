using Light2D.Colors;

namespace Light2D.Shapes
{
    public class Circle : Shape
    {
        public Vector2 Position { get; }
        public double Radius { get; }

        public Circle(Vector2 position, double radius, RGBColor diffuse, RGBColor emissive) : base(diffuse, emissive)
        {
            Position = position;
            Radius = radius;
        }

        public override double Distance(Vector2 u)
        {
            return Vector2.Distance(Position, u) - Radius; 
        }
    }
}