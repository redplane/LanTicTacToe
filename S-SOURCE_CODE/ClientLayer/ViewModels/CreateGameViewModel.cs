using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLayer.ViewModels
{
    public class CreateGameViewModel
    {
        /// <summary>
        /// This property contains error message which will be displayed on screen.
        /// </summary>
        public string ErrorMessage { get; set; } = "";

        /// <summary>
        /// This property holds information of the port at which server will be opened.
        /// </summary>
        public string ServerPort { get; set; }
    }
}
