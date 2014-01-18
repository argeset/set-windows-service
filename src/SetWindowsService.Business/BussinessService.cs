using System;
using SetWindowsService.Business.Contract;

namespace SetWindowsService.Business
{
    public class BussinessService : BaseService, IBussinessService
    {
        public void DoWork()
        {
            Console.WriteLine("I do something");
        }
    }
}
