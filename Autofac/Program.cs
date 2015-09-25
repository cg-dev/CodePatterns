namespace Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MessageA>().As<IMessage>();
            builder.RegisterType<Logic>();

            var container = builder.Build();

            var logic = container.Resolve<Logic>();

            logic.Run();
        }
    }
}
