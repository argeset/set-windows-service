using System.ServiceModel;

namespace SetWindowsService.Business.Contract
{
    [ServiceContract]
    public interface IBussinessService
    {
        [OperationContract]
        void DoWork();
    }
}