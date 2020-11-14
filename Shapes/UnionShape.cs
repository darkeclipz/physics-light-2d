using System;

namespace Light2D.Shapes
{
    public class UnionShape : Shape 
    {
        public Shape A { get; }
        public Shape B { get; }
        
        public UnionShape(Shape a, Shape b)
        {
            A = a;
            B = b;
        }

        public override double Distance(Vector2 u)
        {
            return Math.Min(A.Distance(u), B.Distance(u));
        }
    }
}