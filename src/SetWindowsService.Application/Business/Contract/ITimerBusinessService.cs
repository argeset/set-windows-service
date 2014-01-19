using System.ServiceModel;

namespace SetWindowsService.Application.Business.Contract
{
    [ServiceContract]
    public interface ITimerBusinessService
    {
        [OperationContract]
        void DoWorkEverySecond();

        [OperationContract]
        void DoWorkEveryMinute();

        [OperationContract]
        void DoWorkEveryHour();

        [OperationContract]
        void DoWorkEveryDay();

        [OperationContract]
        void DoWorkEveryWeek();

        [OperationContract]
        void DoWorkEveryMonth();
    }
}