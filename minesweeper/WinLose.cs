using minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class WinLose
    {
        public static int WinOrLose { get; set; }

        public static void WinLoseChecker()
        {
            if (WinOrLose == 1)
            {
                PrintGameOver();
            }
            else if (WinOrLose == 2)
            {
                
            }
        }
        public static void PrintGameOver()
        {
            var content = File.ReadAllText("Resources/GameOverText.txt");

            Console.Clear();
            var representation = Representation.Red(content);
            representation.Print();
            Timer.printTimerGameOver();
            return;
        }
    }
}
