using System;

namespace OO
{
    interface IPainter
    {
        bool IsAvailable { get; set; }
        double EstimateCost(double squareMetres);
        TimeSpan EstimateTime(double squareMetres);
    }
}