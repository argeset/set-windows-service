using System.ServiceModel;

namespace SetWindowsService.Application.Business.Contract
{
    [ServiceContract]
    public interface IBusinessService
    {
        [OperationContract]
        void DoWork();
    }
}