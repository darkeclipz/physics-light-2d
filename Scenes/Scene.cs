using System;
using System.Collections.Generic;
using Light2D.Colors;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class Scene
    {
        private List<Shape> Shapes { get; } = new List<Shape>();
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
    }
}