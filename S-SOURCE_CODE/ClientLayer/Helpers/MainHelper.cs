namespace ClientLayer.Helpers
{
    public class MainHelper
    {
        private static MainHelper _instance;

        public static MainHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainHelper();

                return _instance;
            }
        }

        public bool IsProcess { get; set; } = false;
        
        /// <summary>
        /// IpAddress of server to which client connects.
        /// </summary>
        public string IpAddress { get; set; } = "127.0.0.1";

        /// <summary>
        /// Port of server to which client connects.
        /// </summary>
        public int Port { get; set; } = 27020;

        /// <summary>
        /// Number of blocks appears vertically and horizontally.
        /// </summary>
        public int Blocks { get; set; } = 3;


        public delegate void GameCreatedHandler();

        public event GameCreatedHandler OnGameCreated;

        public void FireEventGameCreated()
        {
            if (OnGameCreated != null)
                OnGameCreated();
        }
    }
}