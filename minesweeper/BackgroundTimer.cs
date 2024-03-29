﻿
namespace minesweeper
{
    internal class BackgroundTimer
    {
        private readonly PeriodicTimer _timer;
        private readonly Action action;

        public BackgroundTimer(TimeSpan span, Action action)
        {
            _timer = new PeriodicTimer(span);
            this.action = action;
        }

        public async Task Start()
        {
            while(await _timer.WaitForNextTickAsync())
            {
                action();
            }
        }
    }
}
