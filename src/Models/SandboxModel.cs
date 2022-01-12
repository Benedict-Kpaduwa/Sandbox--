using System.ComponentModel;

public class SandboxModel : INotifyPropertyChanged
{
    public SandboxModel()
    {

    }

    public string executable_filename;

    public string ExecutableFilename
    {
        get { return executable_filename; }
        set { executable_filename = value; OnPropertyChanged("ExecutableFilename"); }
    }

    public string command_line_parameters;

    public string CommandLineParameters
    {
        get { return command_line_parameters; }
        set { command_line_parameters = value; OnPropertyChanged("CommandLineParameters"); }
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