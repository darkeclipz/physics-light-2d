using System;
using System.Collections.Generic;
using Light2D.Colors;
using Light2D.Rendering;
using Light2D.Shapes;

namespace Light2D.Scenes
{
    public class RGBScene : Scene
    {
        public RGBScene() : base(ambient: RGBColor.FromRGB(0.15))
        {
            int n = 3;
            float r = 0.2f;
            var lightMaterials = new List<Material>() { Materials.RedLight, Materials.GreenLight, Materials.BlueLight };
            foreach(var material in lightMaterials)
            {
                material.Intensity = 2.0;
            }
            for(int i = 0; i < n; i++)
            {
                var theta = 2.0 * Math.PI * i / n + Math.PI / 2;
                (var x, var y) = (r * Math.Cos(theta), r * Math.Sin(theta));
                AddShape(new Circle(new Vector2(x, y), radius: 0.15, lightMaterials[i]));
            }

            n = 12;
            r = 0.65f;
            for(int i = 0; i < n; i++)
            {
                var theta = 2.0 * Math.PI * i / n + Math.PI / 2;
                var material = Materials.Default;
                material.DiffuseColor = RGBColor.FromRGB(0.5);
                (var x, var y) = (r * Math.Cos(theta), r * Math.Sin(theta));
                AddShape(new Circle(new Vector2(x, y), radius: 0.025, material));
            }
        }
    }
}