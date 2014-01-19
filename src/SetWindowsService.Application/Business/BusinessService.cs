using System;

using SetWindowsService.Application.Business.Contract;

namespace SetWindowsService.Application.Business
{
    public class BusinessService : BaseService, IBusinessService
    {
        public void DoWork()
        {
            Console.WriteLine("I do something");
        }
    }
}
