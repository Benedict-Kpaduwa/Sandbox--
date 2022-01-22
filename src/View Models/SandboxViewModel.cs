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
                new PermissionsModel
                {
                    PermissionsHeader = nameof(EnvironmentPermission), 
                    PermissionsContent = new ObservableCollection<string>(System.Enum.GetNames(typeof(EnvironmentPermissionAccess))) 
                },
                new PermissionsModel
                {
                    PermissionsHeader = nameof(FileDialogPermission),
                    PermissionsContent = new ObservableCollection<string>(System.Enum.GetNames(typeof(FileDialogPermissionAccess)))
                },
                new PermissionsModel
                {
                    PermissionsHeader = nameof(FileIOPermission), 
                    PermissionsContent =  new ObservableCollection<string>(System.Enum.GetNames(typeof(FileIOPermissionAccess))) 
                },
                new PermissionsModel
                {
                    PermissionsHeader = nameof(RegistryPermission),
                    PermissionsContent = new ObservableCollection<string>(System.Enum.GetNames(typeof(RegistryPermissionAccess)))
                },
                new PermissionsModel
                {
                    PermissionsHeader = nameof(SecurityPermission),
                    PermissionsContent = new ObservableCollection<string>(System.Enum.GetNames(typeof(SecurityPermissionFlag)))
                },
                new PermissionsModel
                {
                    PermissionsHeader = nameof(UIPermission),
                    PermissionsContent = new ObservableCollection<string>(System.Enum.GetNames(typeof(UIPermissionWindow)))
                }
            };
        }

        private ICommand clear_command;

        public ICommand OnClearCommand
        {
            get { if (clear_command == null) clear_command = new ClearCommand(this); return clear_command; }
            set { clear_command = value; }
        }

        private ICommand browse_command;

        public ICommand OnBrowseCommand
        {
            get { if (browse_command == null) browse_command = new BrowseCommand(this); return browse_command; }
            set { browse_command = value; }
        }

        private ICommand run_command;

        public ICommand OnRunCommand
        {
            get { if(run_command == null) run_command = new RunCommand(this); return run_command; }
            set { run_command = value; }
        }
    }
}