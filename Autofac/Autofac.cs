using System;

namespace Autofac
{
    class Program
    {
        static void Main()
        {
            var service = new w3schools.TempConvert(); // Added as web reference

            //var builder = new ContainerBuilder();
            //builder.RegisterType<com.w3schools.www.TempConvert>().As<IService>();
            //var container = builder.Build();

            //var service = container.Resolve<IService>();

            Console.WriteLine("Celsius: {0} = farenheit, {1}", 0, service.CelsiusToFahrenheit("0"));
            Console.WriteLine("Celsius: {0} = farenheit, {1}", 16, service.CelsiusToFahrenheit("16"));
            Console.WriteLine("Celsius: {0} = farenheit, {1}", 100, service.CelsiusToFahrenheit("100"));
            Console.WriteLine("Farenheit: {0} = celsius, {1}", 0, service.FahrenheitToCelsius("0"));
            Console.WriteLine("Farenheit: {0} = celsius, {1}", 32, service.FahrenheitToCelsius("32"));
            Console.WriteLine("Farenheit: {0} = celsius, {1}", 100, service.FahrenheitToCelsius("100"));
            Console.ReadLine();
        }
    }
}