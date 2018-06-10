using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter message to be sent");
            Console.WriteLine("(High priority messages should start with '!:')");
            string message = Console.ReadLine();


            MessageQueue queue;
            if (MessageQueue.Exists(@".\Private$\queue"))
            {
                queue = new MessageQueue(@".\Private$\queue");
            }
            else
            {
                queue = MessageQueue.Create(@".\Private$\queue");
            }

            Message myMessage = new Message();

            myMessage.Formatter = new BinaryMessageFormatter();
            myMessage.Body = message;
            myMessage.Label = "SenderMessage";

            if(message.Contains("!:"))
            {
                myMessage.Priority = MessagePriority.Highest;
            }
            else
            {
                myMessage.Priority = MessagePriority.Normal;
            }

            queue.Send(myMessage);
            Console.WriteLine("Your message has been sent! Good luck repairing your OS!");
            Console.ReadKey();
        }
    }
}
