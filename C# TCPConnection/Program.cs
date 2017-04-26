using System;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Communication com = new Communication();
            com.connect();
            Packet packet = new Packet(0);

            while (true)
            {
                String input = Console.ReadLine();
                switch (input)
                {
                    case "r":
                        Console.WriteLine("\n\rReceive Mode\r\n");
                        com.receive();
                        com.start();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case "s":
                        Console.WriteLine("\n\rSend Mode\r\n");
                        com.send();
                        com.start();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }  
            } 
        }
    }
}
