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
        //private TcpListener server;
        //private NetworkStream netStream;

        Packet packet = new Packet(0);
        private static string response;
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        private static ManualResetEvent connectDone = new ManualResetEvent(false);

        public Communication() {

        }

        public void start()
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.0.3"), port);
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(ep, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                receive(client);
                receiveDone.WaitOne();
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //Console.WriteLine("----------------------------------------");
            //Console.WriteLine("Type 'r' to enter Receive Mode");
            //Console.WriteLine("\nType 's' to enter Send Mode");
            //Console.WriteLine("----------------------------------------");
            //Console.WriteLine("");
        }
        public static void connect(EndPoint remoteEP, Socket client)
        {
            //try
            // {
            //     Console.WriteLine("Starting TCP Listener");     
            //     IPAddress ownip = IPAddress.Parse("192.168.0.3");

            //     //TCP Server
            //     server = new TcpListener(ownip, port);

            //     //Listening to clients
            //     server.Start();
            //     start();
            // }catch(SocketException e)
            // {
            //     Console.WriteLine("SocketException: {0}", e);
            // }

            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);

            connectDone.WaitOne();
        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int receive(Socket client)
        {
            try { 
                // Create state object
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
                return state.getPokemon();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }

            //TcpClient client;
            //client = server.AcceptTcpClient();
            //NetworkStream netStream = client.GetStream();

            //Console.WriteLine("Connection with handheld!\r\n");
            //if (netStream.CanRead)
            //{
            //    int bufferSize = 0;
            //    bufferSize = client.Available;
            //    byte[] bytes = new byte[bufferSize];
            //    netStream.Read(bytes, 0, bufferSize);

            //    this.packet.addReceivedPacket(bytes);
            //    Console.WriteLine("Pokemon: " + packet.getPokemon());
            //}
            //else
            //{
            //    Console.WriteLine("You cannot read data from this stream");
            //    client.Close();
            //    netStream.Close();
            //    return;
            //}
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    //  Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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
