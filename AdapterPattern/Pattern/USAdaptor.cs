using System;

namespace AdapterPattern.Pattern
{
    public class USAdaptor : IAdaptor
    {
        private USPlug _plug = new USPlug();

        public string On()
        {
            return _plug.TurnOn();
        }
    }
}