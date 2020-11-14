using Light2D.Colors;

namespace Light2D.Shapes
{
    public abstract class Shape
    {
        public RGBColor DiffuseColor { get; private set; }
        public RGBColor EmissiveColor { get; private set; }

        public Shape() : this(RGBColor.Black, RGBColor.Black) { }
        public Shape(RGBColor diffuseColor) : this(diffuseColor, RGBColor.Black) { }
        public Shape(RGBColor diffuseColor, RGBColor emissiveColor)
        {
            DiffuseColor = diffuseColor;
            EmissiveColor = emissiveColor;
        }

        public abstract double Distance(Vector2 u);
        public static UnionShape Union(Shape a, Shape b) => new UnionShape(a, b);
    }
}