using System.ComponentModel;

namespace src.Models
{
    public class PermissionsModel : INotifyPropertyChanged
    {
        public PermissionsModel()
        {

        }

        private string permissions_header;

        public string PermissionsHeader
        {
            get { return permissions_header; }
            set { permissions_header = value; OnPropertyChanged(nameof(PermissionsHeader)); }
        }

        public string permissions_content { get; set; }

        public string PermissionsContent
        {
            get { return permissions_content; }
            set { permissions_content = value; OnPropertyChanged(nameof(PermissionsContent)); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
