namespace AdapterPattern.Pattern
{
    public class UKPlug : IAdaptor
    {
        public string On()
        {
            return "Power is flowing from a UK plug";
        }
    }
}
