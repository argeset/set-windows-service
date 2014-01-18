using System.ServiceModel;

namespace SetWindowsService.Application.Business.Contract
{
    [ServiceContract]
    public interface IBussinessService
    {
        [OperationContract]
        void DoWork();
    }
}