using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using ClientLayer.Helpers;
using ClientLayer.Models;
using ClientLayer.Views.Dialogs;
using GalaSoft.MvvmLight.Command;
using SharedLayer.Enums;

namespace ClientLayer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _message;

        public bool IsProcess
        {
            get { return MainHelper.Instance.IsProcess; }
            set
            {
                NotifyPropertyChanged("IsProcess");
            }
        }

        public string Message
        {
            get { return _message;}
            set
            {
                _message = value;
                NotifyPropertyChanged("Message");
            }
        }

        public RelayCommand<Window> CommandShowCreateGameDialog { get; private set; }

        /// <summary>
        /// This event is used for firing PropertyChanged 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        #region Constructors

        /// <summary>
        /// Initialize an object of MainViewModel with no input value.
        /// </summary>
        public MainViewModel()
        {
            _message = "";

            // Relay command initialization
            CommandShowCreateGameDialog = new RelayCommand<Window>(DisplayCreateGameDialog);
        }

        #endregion

        #region Methods

        /// <summary>
        /// This function is for displaying Create game dialog.
        /// </summary>
        /// <param name="srcFrame"></param>
        private void DisplayCreateGameDialog(Window srcFrame)
        {
            var createGameDialog = new CreateGameDialog();
            createGameDialog.Owner = srcFrame;
            var dialogResult = createGameDialog.ShowDialog();
            
            MainHelper.Instance.OnGameCreated += InstanceOnOnGameCreated;

            try
            {
                if (dialogResult != null && dialogResult.Value)
                {
                    
                }
            }
            catch (Exception exceptionInfo)
            {
                Message += string.Format("{0}\n", exceptionInfo.Message);
            }
        }

        private void InstanceOnOnGameCreated()
        {
            Message += string.Format("InstanceOnOnGameCreated\n");
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