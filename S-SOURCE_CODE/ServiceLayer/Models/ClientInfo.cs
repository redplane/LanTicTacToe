using SharedLayer.Enums;
using SharedLayer.Models;

namespace ServiceLayer.Models
{
    public class ClientInfo : ClientInfoBase
    {
        /// <summary>
        /// Role of client [Game creator / Game connector].
        /// By default, client role is Client.
        /// </summary>
        public ClientRoles Role { get; set; } = ClientRoles.Client;

        /// <summary>
        /// Symbol which user selected.
        /// </summary>
        public Symbol SelectedSymbol { get; set; } = Symbol.O;
    }
}