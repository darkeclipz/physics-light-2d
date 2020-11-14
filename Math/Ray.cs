using System;

namespace Light2D
{
    public class Ray
    {
        public Vector2 Position { get; }
        public Vector2 Direction { get; }

        public Ray(Vector2 position, Vector2 direction)
        {
            this.Direction = direction;
            this.Position = position;    
        }

        public Vector2 GetPoint(double t) => Position + t * Direction;
    }
}