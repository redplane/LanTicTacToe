using System.IO;
using System.Net.Sockets;
using SharedLayer.Enums;

namespace ClientLayer.Models
{
    public class ClientInfo
    {
        #region Properties

        /// <summary>
        /// Key which is generated from server to identify client.
        /// </summary>
        public string IdentityKey { get; set; }

        /// <summary>
        /// Role of this client. This determine the method messages will be sent.
        /// </summary>
        public ClientRoles Role { get; set; } = ClientRoles.Client;

        /// <summary>
        /// Socket connection which client uses for connecting to server.
        /// </summary>
        public TcpClient TcpConnection { get; set; }

        /// <summary>
        /// Stream which client uses for receiving message from server.
        /// </summary>
        public StreamReader StreamDataReceive { get; set; }

        /// <summary>
        /// Stream which client uses for sending message to server.
        /// </summary>
        public StreamWriter StreamDataSend { get; set; }

        /// <summary>
        /// This property is only available on server-side, this manages the symbol client seleted.
        /// </summary>
        public Symbol SelectedSymbol { get; set; }

        #endregion
    }
}