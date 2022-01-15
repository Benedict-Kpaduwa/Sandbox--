using System.Windows.Input;

internal class ClearCommand : ICommand
{
    private SandboxViewModel ViewModel { get; set; }

    public ClearCommand(SandboxViewModel ViewModel)
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
        return !System.String.IsNullOrEmpty(ViewModel.SandboxModel.ConsoleLog);
    }

    public void Execute(object parameter)
    {
        ViewModel.SandboxModel.ConsoleLog = "";
    }

    #endregion
}