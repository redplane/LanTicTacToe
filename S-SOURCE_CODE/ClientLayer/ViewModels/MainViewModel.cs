using System.Windows;
using ClientLayer.Helpers;
using ClientLayer.Views.Dialogs;
using GalaSoft.MvvmLight.Command;

namespace ClientLayer.ViewModels
{
    public class MainViewModel
    {

        public bool IsGameStarted
        {
            get { return true; }
        }
        public RelayCommand<Window> CommandShowCreateGameDialog { get; private set; }

        #region Constructors

        /// <summary>
        /// Initialize an object of MainViewModel with no input value.
        /// </summary>
        public MainViewModel()
        {
            // Relay command initialization
            CommandShowCreateGameDialog = new RelayCommand<Window>(DisplayCreateGameDialog);
        }

        #endregion

        #region Methods

        private void DisplayCreateGameDialog(Window srcFrame)
        {
            var createGameDialog = new CreateGameDialog();
            createGameDialog.Owner = srcFrame;
            createGameDialog.ShowDialog();
        }

        #endregion
    }
}