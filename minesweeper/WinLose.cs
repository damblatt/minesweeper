using minesweeper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class WinLose
    {
        public static bool IsLost { get; set; }

        public static bool WinLoseChecker(Grid grid, int amountOfGuesses)
        {
            if (IsLost && amountOfGuesses == 1)
            {
                PrintSkillIssue();
                return true;
            }
            else if (IsLost)
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
        }

        public static void PrintGameOver()
        {
            var content = File.ReadAllText("Resources/GameOverText.txt");

            Console.Clear();
            PlayGameOver();
            var representation = Representation.Red(content);
            representation.Print();
            Console.WriteLine("\tYou sadly flipped a field which contained a mine. Better Luck next time.");
            Timer.printTimerGameOver();
            return;
        }

        public static void PrintSkillIssue()
        {
            var content = File.ReadAllText("Resources/SkillIssue.txt");

            Console.Clear();
            PlayGameOver();
            var representation = Representation.Red(content);
            representation.Print();
            Console.WriteLine("\tThe first field you flipped sadly contained a mine. Better Luck next time.");
            Timer.printTimerGameOver();
            return;
        }

        private static void PlayGameOver()
        {
            SoundPlayer gameOver = new SoundPlayer("Resources/gameOver.wav");
            gameOver.Play();
        }

        public static void PrintVictory()
        {
            var content = File.ReadAllText("Resources/Victory.txt");

            Console.Clear();
            SoundPlayer victory = new SoundPlayer("Resources/victory.wav");
            victory.Play();
            var representation = Representation.Green(content);
            representation.Print();
            Timer.printTimerGameOver();
            return;
        }
    }
}