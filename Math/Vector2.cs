using System;

namespace Light2D
{
    public sealed class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y) 
        {
            X = x;
            Y = y;
        }
        public Vector2(double x) : this(x, x) { }
        public Vector2() : this(0, 0) { }

        public static Vector2 operator +(Vector2 u, Vector2 v) => new Vector2(u.X + v.X, u.Y + v.Y);
        public static Vector2 operator -(Vector2 u, Vector2 v) => new Vector2(u.X - v.X, u.Y - v.Y);
        public static Vector2 operator *(Vector2 u, float scalar) => new Vector2((double)scalar * u.X, (double)scalar * u.Y);
        public static Vector2 operator *(float scalar, Vector2 u) => new Vector2((double)scalar * u.X, (double)scalar * u.Y);
        public static Vector2 operator *(int scalar, Vector2 u) => new Vector2((double)scalar * u.X, (double)scalar * u.Y);
        public static Vector2 operator *(Vector2 u, int scalar) => new Vector2((double)scalar * u.X, (double)scalar * u.Y);
        public static Vector2 operator *(Vector2 u, double scalar) => new Vector2(scalar * u.X, scalar * u.Y);
        public static Vector2 operator *(double scalar, Vector2 u) => new Vector2(scalar * u.X, scalar * u.Y);
        public static Vector2 operator %(Vector2 p, Vector2 c) => new Vector2(p.X % c.X, p.Y % c.Y);
        public override string ToString() => $"({X}, {Y})";
        public Vector2 Copy() => (Vector2)this.MemberwiseClone();

        public double Length() => Math.Sqrt(Vector2.Dot(this, this));
        public double LengthSquared() => Vector2.Dot(this, this);
        public Vector2 Normalize()  
        {
            var length = Length();
            return new Vector2(X / length, Y / length);
        }

        public static double Dot(Vector2 u, Vector2 v) => u.X * v.X + u.Y * v.Y;
        public static double Distance(Vector2 u, Vector2 v) => (v - u).Length();
        public static double DistanceSquared(Vector2 u, Vector2 v) => (v - u).LengthSquared();
        public static Vector2 Abs(Vector2 u) => new Vector2(Math.Abs(u.X), Math.Abs(u.Y));
        public static Vector2 Max(Vector2 u, double c) => new Vector2(Math.Max(u.X, c), Math.Max(u.Y, c));
        public static Vector2 Min(Vector2 u, double c) => new Vector2(Math.Min(u.X, c), Math.Min(u.Y, c));
    }
}