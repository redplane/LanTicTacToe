using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLayer.Helpers
{
    /// <summary>
    /// This helper class is for retrieving/storing information which will be accessed through all game section.
    /// </summary>
    internal class MainHelper
    {
        #region Private properties

        /// <summary>
        /// Static instance of MainHelper.
        /// </summary>
        private static MainHelper _instance;
        
        #endregion

        #region Public properties

        /// <summary>
        /// Retrieve static instance of MainHelper.
        /// </summary>
        public static MainHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainHelper();

                return _instance;
            }
        }

        /// <summary>
        /// Port of server to which client will connect.
        /// By default, server will be opened at port 27015.
        /// </summary>
        public int ServerPort { get; set; } = 27015;

        /// <summary>
        /// Number of blocks appear in a row.
        /// By default, 3 blocks appear in a row.
        /// </summary>
        public int HorizontalBlocks { get; set; } = 3;

        /// <summary>
        /// Number of blocks appear in a column.
        /// By default, 3 blocks appear in a column.
        /// </summary>
        public int VerticalBlocks { get; set; } = 3;

        #endregion

    }
}
