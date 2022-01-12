﻿using System.Windows.Input;

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

    public ICommand browse_command;

    public ICommand OnBrowseCommand
    {
        get { return browse_command ??= new BrowseCommand(this); }
        set { browse_command = value; }
    }

    private ICommand clear_command;

    public ICommand OnClearCommand
    {
        get { return clear_command ??= new ClearCommand(this); }
        set { clear_command = value; }
    }
}