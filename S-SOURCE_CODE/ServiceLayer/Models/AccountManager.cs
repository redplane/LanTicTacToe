using System.Collections.Generic;
using ServiceLayer.Helpers;
using SharedLayer.Interfaces;

namespace ServiceLayer.Models
{
    public class AccountManager : IAccountManager
    {
        public bool RegisterAccount(string accountName)
        {
            AccountsHelper.Instance.AccountList.Add(accountName);
            return true;
        }

        public bool RemoveAccount(string accountName)
        {
            return true;
        }

        public IList<string> RetrieveAccountsList()
        {
            var retrievedList = new List<string>(AccountsHelper.Instance.AccountList);
            return retrievedList;
        }
    }
}