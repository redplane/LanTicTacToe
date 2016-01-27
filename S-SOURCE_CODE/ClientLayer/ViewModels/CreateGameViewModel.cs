using System;
using System.ComponentModel;
using System.Windows;
using ClientLayer.Helpers;
using GalaSoft.MvvmLight.Command;

namespace ClientLayer.ViewModels
{
    internal class CreateGameViewModel : INotifyPropertyChanged
    {

        #region Variables
        
        /// <summary>
        /// Store message of error happened.
        /// </summary>
        private string _errorMessage;
        
        /// <summary>
        /// This event is used for firing PropertyChanged 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        #endregion

        #region Properties

        /// <summary>
        /// Get/set port at which server will run.
        /// </summary>
        public int ServerPort
        {
            get { return MainHelper.Instance.Port; }
            set
            {
                MainHelper.Instance.Port = value;

                // Notify this property has been changed.
                NotifyPropertyChanged("ServerPort");
            }
        }

        /// <summary>
        /// Get error message caused while starting a server.
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            private set
            {
                // Nothing has been changed. Do nothing.
                if (_errorMessage != null && _errorMessage.Equals(value))
                    return;

                // Update server port.
                _errorMessage = value;

                // Notify this property has been changed.
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        /// <summary>
        /// Retrieve/Set number of blocks appear in a row.
        /// </summary>
        public int Blocks
        {
            get { return MainHelper.Instance.Blocks; }
            set
            {
                // Update new setting.
                MainHelper.Instance.Blocks = value;

                // Notify another control this value has been changed.
                NotifyPropertyChanged("Blocks");
            }
        }
        
        /// <summary>
        /// IP Address of server
        /// </summary>
        public string IpAddress
        {
            get { return MainHelper.Instance.IpAddress; }
            set
            {
                MainHelper.Instance.IpAddress = value;
                NotifyPropertyChanged("IpAddress");
            }
        }

        /// <summary>
        /// Holds the function which will be fired when start button is clicked.
        /// </summary>
        public RelayCommand<Window> CommandConfirmSettings { get; private set; }

        #endregion
        
        #region Methods

        /// <summary>
        /// Default constructor of CreateGameViewModel.
        /// Initialize default value for controls.
        /// </summary>
        public CreateGameViewModel()
        {
            // Reset all properties.
            //_serverPort = MainHelper.Instance.ServerPort;
            //_errorMessage = "";
            //_horizontalBlocks = MainHelper.Instance.HorizontalBlocks;
            //_verticalBlocks = MainHelper.Instance.VerticalBlocks;
            
            // Command registration.
            CommandConfirmSettings = new RelayCommand<Window>(ConfirmSettings);
        }
        
        /// <summary>
        /// This function is used for starting server.
        /// </summary>
        private void ConfirmSettings(Window srcDialog)
        {
            try
            {
                // Clear all error messages.
                ErrorMessage = "";
                
                // Update server port.
                //MainHelper.Instance.ServerPort = _serverPort;

                srcDialog.DialogResult = true;
            }
            catch (Exception)
            {
                // Display an error message to screen.
                ErrorMessage = "An error occured while starting server. Please try again";

                srcDialog.DialogResult = false;
            }
        }

        /// <summary>
        /// This function is used for firing PropertyChanged event to notify another controls a property has been changed.
        /// </summary>
        /// <param name="propertyName">Name of property</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion

    }
}
