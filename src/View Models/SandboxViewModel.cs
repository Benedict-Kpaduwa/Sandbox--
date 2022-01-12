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
}