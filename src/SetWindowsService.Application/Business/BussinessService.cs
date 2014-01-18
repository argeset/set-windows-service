using System;
using SetWindowsService.Application.Business.Contract;

namespace SetWindowsService.Application.Business
{
    public class BussinessService : BaseService, IBussinessService
    {
        public void DoWork()
        {
            Console.WriteLine("I do something");
        }
    }
}
