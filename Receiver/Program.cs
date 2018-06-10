using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Newest message: ");

            MessageQueue queue;
            queue = new MessageQueue(@".\Private$\queue");

            Message message = queue.Receive();
            message.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(message.Body.ToString());
            Console.ReadKey();
            
        }
    }
}
