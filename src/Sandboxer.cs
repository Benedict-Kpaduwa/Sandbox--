using System;
using System.IO;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Policy;

namespace src
{
    public class Sandboxer : MarshalByRefObject
    {
        public void ApplicationInitialise(string executable_filename, string command_line_parameters, PermissionSet permissions)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = Path.GetDirectoryName(executable_filename);

            StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();

            Random rnd = new Random();
            AppDomain newDomain = AppDomain.CreateDomain("Sandbox" + rnd.Next().ToString(), null, setup, permissions, fullTrustAssembly);

            ObjectHandle handle = Activator.CreateInstanceFrom(
                newDomain,
                typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
                typeof(Sandboxer).FullName);

            try
            {
                Sandboxer newDomainInstance = (Sandboxer)handle.Unwrap();
                newDomain.ExecuteAssembly(executable_filename, command_line_parameters?.Split(' '));
            }
            catch (BadImageFormatException e)
            {
                System.Windows.MessageBox.Show($"{e.Message}");
            }
        }
    }
}
