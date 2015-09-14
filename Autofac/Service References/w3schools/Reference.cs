﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autofac.w3schools {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.w3schools.com/webservices/", ConfigurationName="w3schools.TempConvertSoap")]
    public interface TempConvertSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.w3schools.com/webservices/FahrenheitToCelsius", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string FahrenheitToCelsius(string Fahrenheit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.w3schools.com/webservices/FahrenheitToCelsius", ReplyAction="*")]
        System.Threading.Tasks.Task<string> FahrenheitToCelsiusAsync(string Fahrenheit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.w3schools.com/webservices/CelsiusToFahrenheit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CelsiusToFahrenheit(string Celsius);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.w3schools.com/webservices/CelsiusToFahrenheit", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CelsiusToFahrenheitAsync(string Celsius);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TempConvertSoapChannel : Autofac.w3schools.TempConvertSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TempConvertSoapClient : System.ServiceModel.ClientBase<Autofac.w3schools.TempConvertSoap>, Autofac.w3schools.TempConvertSoap {
        
        public TempConvertSoapClient() {
        }
        
        public TempConvertSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TempConvertSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TempConvertSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TempConvertSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string FahrenheitToCelsius(string Fahrenheit) {
            return base.Channel.FahrenheitToCelsius(Fahrenheit);
        }
        
        public System.Threading.Tasks.Task<string> FahrenheitToCelsiusAsync(string Fahrenheit) {
            return base.Channel.FahrenheitToCelsiusAsync(Fahrenheit);
        }
        
        public string CelsiusToFahrenheit(string Celsius) {
            return base.Channel.CelsiusToFahrenheit(Celsius);
        }
        
        public System.Threading.Tasks.Task<string> CelsiusToFahrenheitAsync(string Celsius) {
            return base.Channel.CelsiusToFahrenheitAsync(Celsius);
        }
    }
}
