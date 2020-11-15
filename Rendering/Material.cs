using Light2D.Colors;

namespace Light2D.Rendering
{
    public class Material
    {
        public RGBColor DiffuseColor { get; set; }
        public RGBColor EmissiveColor { get; set; }
        public double Intensity { get; set; }
        public double Reflectivity { get; set; }
        public double Refractivity { get; set; }
        public double RefractiveIndex { get; set; }
        public double Roughness { get; set; }

        public Material(RGBColor diffuseColor, RGBColor emissiveColor, double intensity, 
                        double reflectivity, double refractivity, double refractiveIndex, 
                        double roughness)
        {
            DiffuseColor = diffuseColor;
            EmissiveColor = emissiveColor;
            Intensity = intensity;
            Reflectivity = reflectivity;
            Refractivity = refractivity;
            RefractiveIndex = refractiveIndex;
            Roughness = roughness;
        }

        public Material(RGBColor diffuseColor, RGBColor emissiveColor, double intensity,
                        double reflectivity, double refractivity, double refractiveIndex)
                        : this(diffuseColor, emissiveColor, intensity, reflectivity, 
                               refractivity, refractiveIndex, 0) { }

        public Material(RGBColor diffuseColor, RGBColor emissiveColor, double intensity,
                        double reflectivity, double refractivity)
                        : this(diffuseColor, emissiveColor, intensity, reflectivity, 
                               refractivity, 1.0, 0) { }

        public Material(RGBColor diffuseColor, RGBColor emissiveColor, double intensity,
                        double reflectivity)
                        : this(diffuseColor, emissiveColor, intensity, reflectivity, 
                               0, 1.0, 0) { }

        public Material(RGBColor diffuseColor, RGBColor emissiveColor, double intensity)
                        : this(diffuseColor, emissiveColor, intensity, 0, 0, 1.0, 0) { }

        public Material(RGBColor diffuseColor, RGBColor emissiveColor)
                        : this(diffuseColor, emissiveColor, 1.0, 0, 0, 1.0, 0) { }

        public Material(RGBColor diffuseColor)
                        : this(diffuseColor, RGBColor.Black, 1.0, 0, 0, 1.0, 0) { }

        public Material() : this(RGBColor.Black) { }
    }

    public static class Materials
    {
        // Standard materials
        public static Material Default { get => new Material(); }
        public static Material Mirror { get => new Material(RGBColor.Black, RGBColor.Black, 1.0, 1.0); }
        public static Material Glass { get => new Material(RGBColor.Black, RGBColor.Black, 1.0, 0.0, 1.0, 1.4); }

        // Emissive materials
        public static Material WhiteLight { get => new Material(RGBColor.White, RGBColor.White, 1.0); }
        public static Material RedLight { get => new Material(RGBColor.Red, RGBColor.Red, 1.0); }
        public static Material GreenLight { get => new Material(RGBColor.Green, RGBColor.Green, 1.0); }
        public static Material BlueLight { get => new Material(RGBColor.Blue, RGBColor.Blue, 1.0); }
    }
}
