using System.IO;
using System.Net.Sockets;
using SharedLayer.Enums;

namespace SharedLayer.Models
{
    public class ClientInfoBase
    {
        #region Properties

        /// <summary>
        /// Key which is generated from server to identify client.
        /// </summary>
        public string IdentityKey { get; set; }
        
        /// <summary>
        /// Stream which client uses for receiving message from server.
        /// </summary>
        public StreamReader StreamDataReceive { get; set; }

        /// <summary>
        /// Stream which client uses for sending message to server.
        /// </summary>
        public StreamWriter StreamDataSend { get; set; }

        #endregion
    }
}