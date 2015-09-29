namespace Autofac
{
    public class Father :IFather
    {
        public ISon Son { get; set; }

        public string Name()
        {
            return "I am my father's son and my son's father";
        }
    }
}