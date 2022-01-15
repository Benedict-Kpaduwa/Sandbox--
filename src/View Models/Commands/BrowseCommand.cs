using System.Windows.Input;

internal class BrowseCommand : ICommand
{
    private SandboxViewModel ViewModel { get; set; }

    public BrowseCommand(SandboxViewModel ViewModel)
    {
        this.ViewModel = ViewModel;
    }

    #region ICommand Members  

    public event System.EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested += value; }
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            ViewModel.SandboxModel.ExecutableFilename = openFileDialog.FileName;

            ViewModel.SandboxModel.ConsoleLog += $"File Selected from file dialog: {openFileDialog.SafeFileName} {System.Environment.NewLine}";
        }
    }

    #endregion
}