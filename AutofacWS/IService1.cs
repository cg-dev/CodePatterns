using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AutofacWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        IResponse GetDataUsingDataContract(IRequest request);

        // TODO: Add your service operations here
    }

    public interface IResponse
    {
        string Message { get; set; }
    }

    public interface IRequest
    {
        bool Value { get; set; }
        string StringValue { get; set; }
    }

    public interface IDataService
    {
        string ReverseMessage(string message);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Request : IRequest
    {
        bool _value = true;
        string _stringValue = "Hello";

        [DataMember]
        public bool Value
        {
            get { return _value; }
            set { _value = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return _stringValue; }
            set { _stringValue = value; }
        }
    }

    [DataContract]
    public class Response : IResponse
    {
        public string Message { get; set; }
    }

    public class DataService : IDataService
    {
        public string ReverseMessage(string message)
        {
            return message.Reverse().ToString();
        }
    }
}