using SharedLayer.Enums;
using SharedLayer.Models;

namespace ClientLayer.Models
{
    public class ClientInfo : ClientInfoBase
    {
         public Roles Role { get; set; } = Roles.Client;
    }
}