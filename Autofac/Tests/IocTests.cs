using NUnit.Framework;

namespace Autofac.Tests
{
    [TestFixture]
    public class IocTests
    {
        [Test]
        public void ResolveShouldShowTheCorrectGrandchildName()
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