﻿using minesweeper.Model;
using System.Media;

namespace minesweeper
{
    internal class WinLose
    {
        public static bool IsLost { get; set; }

        public static bool WinLoseChecker(Grid grid, int amountOfGuesses, Timer timer)
        {
            if (IsLost && amountOfGuesses == 1)
            {
                PrintSkillIssue(timer);
                return true;
            }
            else if (IsLost)
            {
                PrintGameOver(timer);
                return true;
            }
            if (grid.IsWon())
            {
                PrintVictory(timer);
                return true;
            }
            return false;
        }

        public static void PrintGameOver(Timer timer)
        {
            var content = File.ReadAllText("Resources/GameOverText.txt");

            Console.Clear();
            PlayGameOver();
            var representation = Representation.Red(content);
            representation.Print();
            Console.WriteLine("\tYou sadly flipped a field which contained a mine. Better Luck next time.");
            timer.PrintTimerGameOver();
            Console.WriteLine("\n\n\nPress any key to get back to the main menu."); 
            Console.ReadKey();
            Program.Game();
        }

        public static void PrintSkillIssue(Timer timer)
        {
            var content = File.ReadAllText("Resources/SkillIssue.txt");

            Console.Clear();
            PlayGameOver();
            var representation = Representation.Red(content);
            representation.Print();
            Console.WriteLine("\tThe first field you flipped sadly contained a mine. Better Luck next time.");
            timer.PrintTimerGameOver();
            Console.WriteLine("\n\n\nPress any key to get back to the main menu.");
            Console.ReadKey();
            Program.Game();
        }

        private static void PlayGameOver()
        {
            SoundPlayer gameOver = new SoundPlayer("Resources/gameOver.wav");
            gameOver.Play();
        }

        public static void PrintVictory(Timer timer)
        {
            var content = File.ReadAllText("Resources/Victory.txt");

            Console.Clear();
            SoundPlayer victory = new SoundPlayer("Resources/victory.wav");
            victory.Play();
            var representation = Representation.Green(content);
            representation.Print();
            timer.PrintTimerGameOver();
            Console.WriteLine("\n\n\nPress any key to get back to the main menu.");
            Console.ReadKey();
            Program.Game();
        }
    }
}