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
            Console.WriteLine($"Time needed until the start of this turn: {duration}");
        }
        public static void printTimerGameOver()
        {
            var duration = DateTime.Now - begin;
            Console.WriteLine($"In total you needed: {duration}");
        }
    }
}
