using System;

namespace Autofac
{
    public class MessageB : IMessage
    {
        public void Display()
        {
            Console.WriteLine("This message should not be seen!");
        }
    }
}
