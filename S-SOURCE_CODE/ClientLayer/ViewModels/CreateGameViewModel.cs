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
        /// Store port of server.
        /// </summary>
        private int _serverPort;

        /// <summary>
        /// Store message of error happened.
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// Setting how many blocks can appear in a row.
        /// </summary>
        private int _horizontalBlocks;

        /// <summary>
        /// Setting how many blocks can appear in a column.
        /// </summary>
        private int _verticalBlocks;
        
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
            get { return _serverPort; }
            set
            {
                // Nothing has been changed. Do nothing.
                if (_serverPort != null && _serverPort.Equals(value))
                    return;

                // Update server port.
                _serverPort = value;

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
        public int HorizontalBlocks
        {
            get { return _horizontalBlocks; }
            set
            {
                // Update new setting.
                _horizontalBlocks = value;

                // Notify another control this value has been changed.
                NotifyPropertyChanged("HorizontalBlocks");
            }
        }

        /// <summary>
        /// Retrieve/Set number of blocks appear in a column.
        /// </summary>
        public int VerticalBlocks
        {
            get { return _verticalBlocks; }
            set
            {
                // Update new setting.
                _verticalBlocks = value;

                // Notify another control this value has been changed.
                NotifyPropertyChanged("VerticalBlocks");
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
