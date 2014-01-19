using System;
using System.Threading;

using SetWindowsService.Application.Business.Contract;

namespace SetWindowsService.Application.Business
{
    public class TimerBusinessService : BaseService, ITimerBusinessService
    {
        private const long TIMER_TICK_SECOND = 1000;
        private const long TIMER_TICK_MINUTE = 60000;
        private const long TIMER_TICK_HOUR = 3600000;
        private const long TIMER_TICK_DAY = 86400000;
        private const long TIMER_TICK_WEEK = 604800000;
        private const long TIMER_TICK_MONTH = 2419200000;

        public void DoWorkEverySecond()
        {
            var timer = new Timer(x => Console.WriteLine("I do something every second"), null, 0, TIMER_TICK_SECOND);
        }

        public void DoWorkEveryMinute()
        {
            var timer = new Timer(x => Console.WriteLine("I do something every minute"), null, 0, TIMER_TICK_MINUTE);
        }

        public void DoWorkEveryHour()
        {
            var timer = new Timer(x => Console.WriteLine("I do something every hour"), null, 0, TIMER_TICK_HOUR);
        }

        public void DoWorkEveryDay()
        {
            var timer = new Timer(x => Console.WriteLine("I do something every day"), null, 0, TIMER_TICK_DAY);
        }

        public void DoWorkEveryWeek()
        {
            var timer = new Timer(x => Console.WriteLine("I do something every week"), null, 0, TIMER_TICK_WEEK);
        }

        public void DoWorkEveryMonth()
        {
            var timer = new Timer(x => Console.WriteLine("I do something every month"), null, 0, TIMER_TICK_MONTH);
        }
    }
}