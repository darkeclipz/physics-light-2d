namespace Light2D.Colors
{
    public class RGBColor
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public RGBColor() : this(0, 0, 0) { }
        public RGBColor(double r) : this(r, r, r) { }
        public RGBColor(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static RGBColor operator +(RGBColor a, RGBColor b) => new RGBColor(a.R + b.R, a.G + b.G, a.B + b.B);
        public static RGBColor operator *(double scalar, RGBColor c) => new RGBColor(scalar * c.R, scalar * c.G, scalar * c.B);
        public static RGBColor operator *(RGBColor c, double scalar) => new RGBColor(scalar * c.R, scalar * c.G, scalar * c.B);
        public static RGBColor operator *(RGBColor a, RGBColor b) => new RGBColor(a.R * b.R, a.G * b.G, a.B * b.B);
        public static RGBColor Black { get => new RGBColor(); }
        public static RGBColor White { get => new RGBColor(1); }
        public static RGBColor Red { get => new RGBColor(1, 0, 0); }
        public static RGBColor Green { get => new RGBColor(0, 1, 0); }
        public static RGBColor Blue { get => new RGBColor(0, 0, 1); }
        public static RGBColor FromRGB(double c) => new RGBColor(c);
        public static RGBColor FromRGB(double r, double g, double b) => new RGBColor(r, g, b);
    }
}