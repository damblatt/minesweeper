using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Timer
    {
        private DateTime begin;

        public bool timerIsRunning { get; set; }

        public void StartTimer()
        {
            begin = DateTime.Now;
            timerIsRunning = true;
        }

        public void PrintTimer()
        {
            var duration = DateTime.Now - begin;
            if (duration.ToString("mm") == "00")
            {
                Console.WriteLine($"Time needed until the start of this turn: {duration.ToString("ss")} seconds");
            }
            else
            {
                Console.WriteLine($"Time needed until the start of this turn: {duration.ToString("mm")} minutes {duration.ToString("ss")} seconds");
            }
        }
        public void PrintTimerGameOver()
        {
            var duration = DateTime.Now - begin;
            if (duration.ToString("mm") == "00")
            {
                Console.WriteLine($"\tIn total you needed: {duration.ToString("ss")} seconds");
            }
            else
            {
                Console.WriteLine($"\tIn total you needed: {duration.ToString("mm")} minutes {duration.ToString("ss")} seconds");
            }
        }
    }
}
