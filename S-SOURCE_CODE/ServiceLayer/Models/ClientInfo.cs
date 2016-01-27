using SharedLayer.Enums;
using SharedLayer.Models;

namespace ServiceLayer.Models
{
    public class ClientInfo : ClientInfoBase
    {
         public Roles Role { get; set; }
    }
}