using System.Collections.Generic;

namespace ServiceLayer.Helpers
{
    public class AccountsHelper
    {
        private static AccountsHelper _instance;
        public List<string> AccountList;

        public AccountsHelper()
        {
            AccountList = new List<string>();
        }

        public static AccountsHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccountsHelper();

                return _instance;
            }
        }
    }
}