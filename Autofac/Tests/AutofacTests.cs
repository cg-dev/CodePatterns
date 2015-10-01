namespace Autofac.Tests
{
    using Autofac;

    using NUnit.Framework;

    [TestFixture]
    public class AutofacTests
    {
        [Test]
        public void ResolveShouldShowTheCorrectGrandchildName()
        {
            //var builder = new ContainerBuilder();

            //builder.RegisterType<Grandfather>().As<IGrandfather>();
            //builder.RegisterType<Father>().As<IFather>();
            //builder.RegisterType<Son>().As<ISon>();
            //builder.RegisterType<Logic>();

            //var container = builder.Build();

            //var logic = container.Resolve<Logic>();

            var son = new Son();
            var father = new Father();
            var grandfather = new Grandfather();

            father.Son = son;
            grandfather.Son = father;

            var logic = new Logic(grandfather, father, son);

            Assert.AreEqual("I am my father's son and my grandfather's grandson. - I am my father's son and my grandfather's grandson.", logic.Run("S"));
        }
    }
}