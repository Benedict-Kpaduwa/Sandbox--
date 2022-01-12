using System.ComponentModel;

public class SandboxModel : INotifyPropertyChanged
{
    public SandboxModel()
    {

    }

    private string console;

    public string Console
    {
        get { return console; }
        set { console = value; OnPropertyChanged("Console"); }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}