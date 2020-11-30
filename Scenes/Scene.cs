using System;
using System.Collections.Generic;
using Light2D.Colors;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class Scene
    {
        protected List<Shape> Shapes { get; } = new List<Shape>();
        public RGBColor AmbientColor { get; private set; }

        public Scene() : this(RGBColor.Black) { }
        public Scene(RGBColor ambient)
        {
            AmbientColor = ambient;
        }

        public (double distance, Shape shape) Distance(Vector2 point)
        {
            var minDistance = double.MaxValue;
            Shape minShape = null;

            foreach(var shape in Shapes) 
            {
                var distance = shape.Distance(point);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    minShape = shape;
                }
            }
            return (minDistance, minShape);
        }

        public void AddShape(Shape shape) => Shapes.Add(shape);
        public Vector2 NormalAtPoint(Vector2 point)
        {
            var eps = new Vector2(0.0001, 0);
            (var x1, _) = Distance(point - eps.XY);
            (var x2, _) = Distance(point + eps.XY);
            (var y1, _) = Distance(point - eps.YX);
            (var y2, _) = Distance(point + eps.YX);
            return new Vector2(x2 - x1, y2 - y1).Normalize();
        }
    }
}