using System.ComponentModel;

namespace ClientLayer.Helpers
{
    public class NotifyPropertyChangedHelper
    {

        #region Variables

        /// <summary>
        /// This event is used to fire NotifyPropertyChange function 
        /// To warn another control the target value has been changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Store static instance of NotifyPropertyChangedHelper class.
        /// </summary>
        private static NotifyPropertyChangedHelper _instance;

        #endregion

        #region Properties

        /// <summary>
        /// Retriev static instance of NotifyPropertyChangedHelper.
        /// </summary>
        public static NotifyPropertyChangedHelper Instance
        {
            get
            {
                // Instance hasn't been initialized.
                if (_instance == null)
                    _instance = new NotifyPropertyChangedHelper();

                return _instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Notify another control a property has been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        public void NotifyPropertyChanged(object sender, string propertyName)
        {
            // Invalid property name.
            if (string.IsNullOrEmpty(propertyName))
                return;

            if (PropertyChanged == null)
                return;

            // Fire PropertyChanged event.
            PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}