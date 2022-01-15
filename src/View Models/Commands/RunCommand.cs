using System.Windows.Input;

internal class RunCommand : ICommand
{
    private SandboxViewModel ViewModel { get; set; }

    public RunCommand(SandboxViewModel ViewModel)
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
        return System.IO.File.Exists(ViewModel.SandboxModel.ExecutableFilename);
    }

    public void Execute(object parameter)
    {
        System.Windows.MessageBox.Show("RunCommand:Execute");
    }

    #endregion
}