using Light2D.Scenes;
using Light2D.Shapes;

namespace Light2D.Rendering
{
    public class Raymarcher
    {
        public double MaxMarchDistance = 2.0;
        public double MinMarchDistance = 0.001;
        public static int MaxRaySteps = 100;
        public SceneDistanceBuffer SDB { get; }
        public Scene Scene { get; }

        public Raymarcher(Scene scene, SceneDistanceBuffer sdb)
        {
            this.Scene = scene;
            this.SDB = sdb;
            MinMarchDistance = sdb.PixelSize / 16;
        }

        public (double distance, Shape shape) March(Ray ray)
        {
            (var t, var dt) = (0.0, 0.0);
            Shape shape = null;
            for (int i = 0; i < MaxRaySteps; i++)
            {
                var p = ray.GetPoint(t);
                dt = SDB.Distance(p);
                if (dt < SDB.PixelSize)
                {
                    (dt, shape) = Scene.Distance(p);
                }
                if (dt < MinMarchDistance) break;
                t += dt;
                if (t > MaxMarchDistance) break;
            }

            if(shape == null && t < MaxMarchDistance)
            {
                var p = ray.GetPoint(t);
                (dt, shape) = Scene.Distance(p);
            }
            
            return (t, shape);
        }
    }
}