using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Timer
    {
        private static DateTime begin;

        public static bool timerIsRunning { get; set; }


        public static void timerStarter()
        {
            begin = DateTime.Now;
            timerIsRunning = true;
        }

        public static void printTimer()
        {
            var duration = DateTime.Now - begin;
            Console.WriteLine($"Time needed until the start of this turn: {duration.ToString("mm")} minutes {duration.ToString("ss")} seconds");
            if (duration.ToString("mm") == "00")
            {
                Console.WriteLine($"Time needed until the start of this turn: {duration.ToString("ss")} seconds");
            }
            else
            {
                Console.WriteLine($"Time needed until the start of this turn: {duration.ToString("mm")} minutes {duration.ToString("ss")} seconds");
            }
        }
        public static void printTimerGameOver()
        {
            var duration = DateTime.Now - begin;
            Console.WriteLine($"\tIn total you needed: {duration.ToString("mm")} minutes {duration.ToString("ss")} seconds");
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
