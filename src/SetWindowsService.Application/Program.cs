using System;
using System.ServiceProcess;

namespace SetWindowsService.Application
{
    class Program
    {
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine("Service is starting!");

                Bootstrapper.Initialize();

                Console.WriteLine("Service started!");
                Console.ReadLine();
            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { new BussinessWindowsService() });
            }
        }
    }
}
