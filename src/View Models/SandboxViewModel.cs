using System.Windows.Input;

/// <summary>
/// 
/// </summary>
public class SandboxViewModel
{
    public SandboxModel SandboxModel { get; set; }

    public SandboxViewModel()
    {
        SandboxModel = new SandboxModel();
    }

    private ICommand clear_command;

    public ICommand OnClearCommand
    {
        get { return clear_command ??= new ClearCommand(this); }
        set { clear_command = value; }
    }

    public ICommand browse_command;

    public ICommand OnBrowseCommand
    {
        get { return browse_command ??= new BrowseCommand(this); }
        set { browse_command = value; }
    }

    private ICommand run_command;

    public ICommand OnRunCommand
    {
        get { return run_command ??= new RunCommand(this); }
        set { run_command = value; }
    }
}