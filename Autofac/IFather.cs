namespace Autofac
{
    public interface IFather
    {
        ISon Son { get; set; }

        string Name();
    }
}