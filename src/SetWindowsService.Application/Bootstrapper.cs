using System;
using System.Linq;
using System.ServiceModel;
using System.Configuration;

using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

using SetWindowsService.Business;
namespace SetWindowsService.Application
{
    public class Bootstrapper
    {
        public static IWindsorContainer Container { get; private set; }

        public static void Initialize()
        {
            Container = new WindsorContainer();
            Container.AddFacility<WcfFacility>();
            Container.AddFacility<LoggingFacility>(f => f.UseNLog());

            var netNamedPipeBinding = new NetNamedPipeBinding
            {
                MaxBufferSize = 67108864,
                MaxReceivedMessageSize = 67108864,
                TransferMode = TransferMode.Streamed,
                ReceiveTimeout = new TimeSpan(0, 30, 0),
                SendTimeout = new TimeSpan(0, 30, 0)
            };

            var netTcpBinding = new NetTcpBinding
            {
                PortSharingEnabled = true,
                Security = new NetTcpSecurity { Mode = SecurityMode.None },
                MaxBufferSize = 67108864,
                MaxReceivedMessageSize = 67108864,
                TransferMode = TransferMode.Streamed,
                ReceiveTimeout = new TimeSpan(0, 30, 0),
                SendTimeout = new TimeSpan(0, 30, 0)
            };

            Container.Register(
               Component.For<ExceptionInterceptor>().LifestyleTransient(),

               Types.FromAssemblyNamed("SetWindowsService.Business")
                    .Pick()
                    .If(type => type.GetInterfaces().Any(i => i.IsDefined(typeof(ServiceContractAttribute), true) && i.Name != typeof(BaseService).Name))
                    .Configure(
                        configurer =>
                        configurer.Named(configurer.Implementation.Name)
                                  .Interceptors<ExceptionInterceptor>()
                                  .LifestyleSingleton()
                                  .AsWcfService(new DefaultServiceModel().AddEndpoints(
                                                    //WcfEndpoint.BoundTo(netTcpBinding)
                                                    //            .At(string.Format("net.tcp://localhost:{1}/{0}", configurer.Implementation.Name, ConfigurationManager.AppSettings["Port"])),
                                                    WcfEndpoint.BoundTo(netNamedPipeBinding)
                                                                .At(string.Format("net.pipe://localhost/{0}", configurer.Implementation.Name)))
                                  .PublishMetadata()))                                 
                                  .WithService.Select((type, baseTypes) => type.GetInterfaces().Where(i => i.IsDefined(typeof(ServiceContractAttribute), true))));
        }
    }
}
