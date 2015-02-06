namespace AdapterPattern.Pattern
{
    public class EuropeanAdaptor : IAdaptor
    {
        private EuropeanPlug _plug = new EuropeanPlug() ;

        public string On()
        {
            return _plug.PowerOn();
        }
    }
}