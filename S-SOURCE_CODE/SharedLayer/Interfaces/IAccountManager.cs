using System.Collections.Generic;
using System.ServiceModel;

namespace SharedLayer.Interfaces
{
    [ServiceContract]
    public interface IAccountManager
    {
        [OperationContract]
        bool RegisterAccount(string accountName);

        [OperationContract]
        bool RemoveAccount(string accountName);

        [OperationContract]
        IList<string> RetrieveAccountsList();

    }
}
