using Light2D.Colors;

namespace Light2D.Shapes
{
    public class Mandelbrot : Shape
    {
        public Mandelbrot(Vector2 position, double scale, RGBColor diffuse, RGBColor emissive) : base(diffuse, emissive) 
        {
            Position = position;
            Scale = scale;
        }

        public Vector2 Position { get; }
        public double Scale { get; }

        public override double Distance(Vector2 u)
        {
            u *= Scale;
            u += Position;

            var z = new Vector2(0);
            int i = 0;
            int maxIterations = 20;
            for(i = 0; i < maxIterations; i++)
            {
                z = new Vector2(z.X * z.X - z.Y * z.Y, 2 * z.X * z.Y) + u;
                if(z.LengthSquared() > 4) 
                {
                    break;
                }
            }

            // return 1.0 - ((double)i - Math.Log(Math.Log(z.LengthSquared() / Math.Log(2.0)) / Math.Log(2.0))) / (double)maxIterations;
            return 1.0 - (double) i / maxIterations;
        }
    }
}