using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace SetWindowsService.Application
{
    [RunInstaller(true)]
    public partial class EasyInstaller : Installer
    {
        public EasyInstaller()
        {
            InitializeComponent();

            var serviceProcess = new ServiceProcessInstaller { Account = ServiceAccount.NetworkService };
            var serviceInstaller = new ServiceInstaller
            {
                ServiceName = "SetWindowsService",
                DisplayName = "Set Windows Service",
                Description = "Describe your service implemtentation here...",
                StartType = ServiceStartMode.Automatic
            };

            Installers.Add(serviceProcess);
            Installers.Add(serviceInstaller);
        }
    }
}
