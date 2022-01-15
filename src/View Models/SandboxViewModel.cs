using System.Collections.ObjectModel;
using System.Security.Permissions;
using System.Windows.Input;
using src.Models;
using src.View_Models.Commands;

namespace src.View_Models
{
    public class SandboxViewModel
    {
        public SandboxModel SandboxModel { get; set; }

        public ObservableCollection<PermissionsModel> PermissionsControls { get; set; }

        public SandboxViewModel()
        {
            SandboxModel = new SandboxModel();

            PermissionsControls = new ObservableCollection<PermissionsModel>()
        {
            new PermissionsModel{PermissionsHeader = nameof(FileDialogPermission), PermissionsContent = "" },
            new PermissionsModel{PermissionsHeader = nameof(DataProtectionPermission), PermissionsContent = "" },
            new PermissionsModel{PermissionsHeader = nameof(SecurityPermission), PermissionsContent = "" }
        };
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
}