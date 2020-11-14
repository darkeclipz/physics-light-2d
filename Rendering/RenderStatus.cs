using System;

namespace Light2D.Rendering
{
    public class RenderStatus
    {
        public int Current { get; private set; } = 0;
        public int Max { get; }

        public RenderStatus(int max)
        {
            this.Max = max;
        }

        public void Increment()
        {
            Current++;
            double percentage = Math.Round((double)Current / Max * 100, 2);
            Console.Write($"\rProgress: {Current}/{Max} ({percentage}%)".PadRight(30, ' '));
        }
    }
}