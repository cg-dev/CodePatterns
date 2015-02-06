namespace AdapterPattern.Tests
{
    using AdapterPattern.Pattern;

    using NUnit.Framework;

    [TestFixture]
    public class AdapterPatternTests
    {
        [Test]
        public void WhenAUSAdaptorIsUsedPowerShouldFlowFromTheSocket()
        {
            var plug = new USAdaptor();

            var result = plug.On();

            Assert.IsTrue(result.Contains("from a US plug"), result);
        }

        [Test]
        public void WhenAEuropeanAdaptorIsUsedPowerShouldFlowFromTheSocket()
        {
            var plug = new EuropeanAdaptor();

            var result = plug.On();

            Assert.IsTrue(result.Contains("from a European plug"), result);
        }

        [Test]
        public void WhenANoAdaptorIsUsedPowerShouldFlowFromTheSocket()
        {
            var plug = new UKPlug();

            var result = plug.On();

            Assert.IsTrue(result.Contains("from a UK plug"), result);
        }
    }
}
