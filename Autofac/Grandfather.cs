namespace Autofac
{
    public class Grandfather :IGrandfather
    {
        public IFather Son { get; set; }

        public string Name()
        {
            return "I am me.";
        }
    }
}