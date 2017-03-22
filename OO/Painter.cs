namespace OO
{
    public class Painter
    {
        public bool IsAvailable { get; set; }
        public double Rate { get; set; }

        public double Estimate(double squareMetres)
        {
            return this.Rate * squareMetres;
        }
    }
}