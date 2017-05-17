using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace TCP
{
    public class Communication
    {

        private Int32 port = 4000;
        private TcpListener server;
  

        Packet packet = new Packet(0);

        public Communication() {

        }

        public void start()
        {

            //Console.WriteLine("----------------------------------------");
            //Console.WriteLine("Type 'r' to enter Receive Mode");
            //Console.WriteLine("\nType 's' to enter Send Mode");
            //Console.WriteLine("----------------------------------------");
            //Console.WriteLine("");
        }
        public void connect()
        {
            try
            {
                Console.WriteLine("Starting TCP Listener");
                IPAddress ownip = IPAddress.Parse("192.168.0.3");

                //TCP Server
                server = new TcpListener(ownip, port);

                //Listening to clients
                server.Start();
                //start();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }


        public void receive()
        {
            TcpClient client;
            client = server.AcceptTcpClient();
            NetworkStream netStream = client.GetStream();

            Console.WriteLine("Connection with handheld!\r\n");
            if (netStream.CanRead)
            {
                int bufferSize = 0;
                bufferSize = client.Available;
                byte[] bytes = new byte[bufferSize];
                netStream.Read(bytes, 0, bufferSize);

                this.packet.addReceivedPacket(bytes);
                Console.WriteLine("Pokemon: " + packet.getPokemon());
            }
            else
            {
                Console.WriteLine("You cannot read data from this stream");
                client.Close();
                netStream.Close();
                return;
            }
        }

        public int getPokemonFromPacket()
        {
            return packet.getPokemon();
        }


        public void send()
        {
            TcpClient client = new TcpClient();
            NetworkStream netStream; 
            try
            {
                
                client.Connect("192.168.0.2", port);
                netStream = client.GetStream();

                if (netStream.CanWrite)
                {
                    byte[] sendPacket = new byte[100];
                    this.packet.addSendPacket(sendPacket);

                    netStream.Write(sendPacket, 0, sendPacket.Length);
                    netStream.Close();
                }
                else
                {
                    Console.WriteLine("You cannot write to this stream");
                    client.Close();
                    netStream.Close();
                    return;
                }
            }catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                client.Close();
                
            }
        }
    }
}
