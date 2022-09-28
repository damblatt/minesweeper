using minesweeper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class WinLose
    {
        //public static int WinOrLose { get; set; }
        public static bool IsLost { get; set; }

        public static bool WinLoseChecker(Grid grid)
        {
            if (IsLost)
            {
                PrintGameOver();
                return true;
            }
            if (grid.IsWon())
            {
                PrintVictory();
                return true;
            }
            return false;
            //if (Field.IsRevealed && Field.IsMine)
            //{
            //    WinLose.WinOrLose = 1;
            //}
            //else if ()
            //{

            //}

            //if (WinOrLose == 1)
            //{
            //    PrintGameOver();
            //}
            //else if (WinOrLose == 2)
            //{
            //    PrintVictory();
            //}
        }

        

        public static void PrintGameOver()
        {
            var content = File.ReadAllText("Resources/GameOverText.txt");
            var representation = Representation.Red(content);
            var content = File.ReadAllText("Resources/GameOverText.txt");
            Console.WriteLine(content);
            return;
        }

        public static void PrintVictory()
        {
            Console.Clear();
            var content = File.ReadAllText("Recources/Victory.txt");
            Console.WriteLine(content);
            Timer.printTimerGameOver();
            return;
        }
    }
}
