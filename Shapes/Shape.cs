using System;
using Light2D.Rendering;

namespace Light2D.Shapes
{
    public abstract class Shape
    {
        public Material Material { get; set; }

        public Shape() : this(Materials.Default) { }
        public Shape(Material material)
        {
            Material = material;
        }

        public abstract double Distance(Vector2 u);
        
        public static double OpRound(double p, double r) => p - r;
        public static double OpOnion(double p, double r) => Math.Abs(p) - r;
        public static double OpUnion(double d1, double d2) => Math.Min(d1, d2);
        public static double OpSubtract(double d1, double d2) => Math.Max(-d1, d2);
        public static double OpIntersect(double d1, double d2) => Math.Max(d1, d2);
        public static Vector2 OpRep(Vector2 p, Vector2 c) => (p + 0.5 * c) % c - 0.5 * c; 
    }
}