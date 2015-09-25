using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac
{
    public class Logic
    {
        IMessage _message;

        public Logic(IMessage message)
        {
            _message = message;
        }

        public void Run()
        {
            Console.WriteLine("This code segment will create an instance of a class using Autofac.");
            _message.Display();
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();
        }
    }
}
