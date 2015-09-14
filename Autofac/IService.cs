using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    interface IService
    {
        string CelsiusToFahrenheit(string celsius);
        string FahrenheitToCelsius(string farenheit);
    }
}
