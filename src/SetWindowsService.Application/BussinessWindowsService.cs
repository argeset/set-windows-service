using System;
using System.ServiceProcess;

using NLog;

namespace SetWindowsService.Application
{
    partial class BussinessWindowsService : ServiceBase
    {
        public BussinessWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Bootstrapper.Initialize();
        }

        protected override void OnStop()
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info(string.Format("Service Shutdown {0:f}", DateTime.Now));
        }
    }
}
