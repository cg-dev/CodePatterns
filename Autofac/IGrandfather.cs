namespace Autofac
{
    public interface IGrandfather
    {
        IFather Son { get; set; }

        string Name();
    }
}