using System;

namespace OO
{
    public class Painter : IPainter
    {
        public bool IsAvailable { get; set; }
        public double Rate { get; set; }
        public TimeSpan Speed { get; set; }

        public double EstimateCost(double squareMetres)
        {
            return this.Rate * squareMetres;
        }

        public TimeSpan EstimateTime(double squareMetres)
        {
            return TimeSpan.FromHours(this.Speed.TotalHours * squareMetres);
        }
    }
}