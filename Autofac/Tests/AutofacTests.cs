using NUnit.Framework;

namespace Autofac.Tests
{
    [TestFixture]
    public class AutofacTests
    {
        [Test]
        public void ResolveShouldShowTheCorrectGrandchildName()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Grandfather>().As<IGrandfather>();
            builder.RegisterType<Father>().As<IFather>();
            builder.RegisterType<Son>().As<ISon>();
            builder.RegisterType<Logic>();

            var container = builder.Build();

            var logic = container.Resolve<Logic>();

            Assert.AreEqual("This", logic.Run("S"));
        }
    }
}