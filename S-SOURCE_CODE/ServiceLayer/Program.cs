using System;
using System.Net;
using System.Net.Sockets;

namespace ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int serverPort;

            #region Input section

            while (true)
            {
                try
                {
                    Console.Write("Server port = ");
                    serverPort = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Invalid server port. Please try again.");
                    Console.ReadLine();
                }
            }

            #endregion

            #region Socket section

            try
            {
                // Open a listener to listen to incomming connection.
                var tcpServer = new TcpListener(IPAddress.Any, serverPort);
                tcpServer.Start();
                Console.WriteLine("Server started.");
                Console.WriteLine("Waiting for incomming connections.");

                //// Create a background thread which handles incomming connection from client-side.
                //var listeningThread = new Thread(() => HandlingIncommingConnectionThread(tcpServer));
                //listeningThread.IsBackground = true;
                //listeningThread.Start();

                Console.ReadLine();
            }
            catch (Exception exceptionInfo)
            {
                Console.WriteLine(exceptionInfo.Message);
                Console.ReadLine();
            }

            #endregion
        }
    }
}
