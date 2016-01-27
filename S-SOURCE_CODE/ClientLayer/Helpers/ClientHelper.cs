namespace ClientLayer.Helpers
{
    public class ClientHelper
    {
        #region Private variables

        /// <summary>
        /// Static instance of ServiceHelper class.
        /// </summary>
        private static ClientHelper _instance;
        
        /// <summary>
        /// Static instance of ClientHelper.
        /// </summary>
        public static ClientHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientHelper();

                return _instance;
            }
        }

        #endregion
    }
}