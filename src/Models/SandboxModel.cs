using System.ComponentModel;

namespace src.Models
{
    public class SandboxModel : INotifyPropertyChanged
    {
        public SandboxModel()
        {

        }

        public string executable_filename;

        public string ExecutableFilename
        {
            get { return executable_filename; }
            set { executable_filename = value; OnPropertyChanged(nameof(ExecutableFilename)); }
        }

        public string command_line_parameters;

        public string CommandLineParameters
        {
            get { return command_line_parameters; }
            set { command_line_parameters = value; OnPropertyChanged(nameof(CommandLineParameters)); }
        }

        private string console_log;

        public string ConsoleLog
        {
            get { return console_log; }
            set { console_log = value; OnPropertyChanged(nameof(ConsoleLog)); }
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
}