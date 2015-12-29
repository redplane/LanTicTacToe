using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServiceLayer.Models;
using SharedLayer.Enums;

namespace ServiceLayer.Helpers
{
    public class ServiceHelper
    {
        private Thread _clientAwaitingThread;
        private Thread clientRequestHandlingThread;

        private static ServiceHelper _instance;
        
        public static ServiceHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceHelper();

                return _instance;
            }
        }
        
        /// <summary>
        /// This function is for starting a thread to wait for incomming clients.
        /// </summary>
        /// <returns></returns>
        public bool Start(int hostPort)
        {
            // Close previously created threads.
            CloseThread(_clientAwaitingThread);
            CloseThread(clientRequestHandlingThread);

            // Close the tcpListener instance as it is avaiable.
            try
            {
                // Initialize an instance of TcpListener to listen to incomming clients.
                var tcpListener = new TcpListener(IPAddress.Any, hostPort);
                
                // Start listening.
                tcpListener.Start();
                
                // Empty client list.
                MainHelper.Instance.Clients = new List<ClientInfo>();
                
                // Initialize the current machine as the first client and its role is Host.
                var clientInfo = new ClientInfo();
                clientInfo.IdentityKey = Guid.NewGuid().ToString();
                clientInfo.Role = ClientRoles.Admin;
                clientInfo.SelectedSymbol = Symbol.X;
                
                // Add this client to list.
                MainHelper.Instance.Clients.Add(clientInfo);

                // Create awaiting thread to wait for incomming clients.
                _clientAwaitingThread = new Thread(() => HandlingIncommingClients(tcpListener));
                _clientAwaitingThread.IsBackground = true;
                _clientAwaitingThread.Start();
            }
            catch
            {
                // Suppress error as it happens.
                return false;
            }

            

            return true;

        }

        /// <summary>
        /// This function is for closing a thread safely.
        /// </summary>
        /// <param name="targetThread"></param>
        private void CloseThread(Thread targetThread)
        {
            try
            {
                if (targetThread != null)
                    targetThread.Abort();
            }
            catch
            {
                // Suppress error as long as the thread cannot be aborted.
            }

            // Reset the variable to null.
            targetThread = null;
        }

        /// <summary>
        /// This thread is for handling a client when it connects to service.
        /// </summary>
        /// <param name="tcpListener"></param>
        private void HandlingIncommingClients(TcpListener tcpListener)
        {
            // This won't stop listening to incomming connections unless the thread is killed or a client connects successfully.
            while (true)
            {
                // Retrieve the client information which connects to server.
                var tcpClient = tcpListener.AcceptTcpClient();

                // Retrieve the stream between client and server.
                var networkStream = tcpClient.GetStream();

                // Initialize retrieve/send data stream.
                var streamDataReceive = new StreamReader(networkStream);
                var streamDataSend = new StreamWriter(networkStream);
                streamDataSend.AutoFlush = true;

                var clientInfo = new ClientInfo();
                clientInfo.StreamDataReceive = streamDataReceive;
                clientInfo.StreamDataSend = streamDataSend;
                clientInfo.IdentityKey = Guid.NewGuid().ToString();
                
                // Add this client to clients list.
                MainHelper.Instance.Clients.Add(clientInfo);

                // Make engine understand the game has been started.
                MainHelper.Instance.IsStarted = true;

                // Create a thread for handling message comming from client.
                var handlingIncommingMessageThread = new Thread(() => HandlingClientRequest(clientInfo));
                handlingIncommingMessageThread.IsBackground = true;
                handlingIncommingMessageThread.Start();

                // Because this application is only for 2 people. When a client is accepted by server, the server stop listening to another clients.
                break;
            }
        }

        /// <summary>
        ///     This thread is for handling stream which sent from client.
        /// </summary>
        /// <param name="clientInfo"></param>
        private async void HandlingClientRequest(ClientInfo clientInfo)
        {
        }
    }
}