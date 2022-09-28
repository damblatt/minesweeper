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

        public static void WinLoseChecker(int numberOfGuesses)
        {
            if (WinOrLose == 1)
            {
                if (numberOfGuesses == 1)
                {
                    PrintSkillIssue();
                }
                else
                {
                    PrintGameOver();
                }
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
            Console.WriteLine("You sadly flipped a field which contained a mine. Better Luck next time.");
            Timer.printTimerGameOver();
            return;
        }
        public static void PrintSkillIssue()
        {
            var content = File.ReadAllText("Resources/SkillIssue.txt");

            Console.Clear();
            var representation = Representation.Red(content);
            representation.Print();
            Console.WriteLine("The first field you flipped sadly contained a mine. Better Luck next time.");
            Timer.printTimerGameOver();
            return;
        }
    }
}
