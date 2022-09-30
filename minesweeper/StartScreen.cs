using minesweeper.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class StartScreen
    {
        public static bool GameIsRunning { get; set; }
        public void PrintStartScreen()
        {
                PrintTitle();
                PrintContent();
                ReadLine();
        }

        public void PrintTitle()
        {
            var content = File.ReadAllText("Resources/ScreenTitle.txt");
            Console.Clear();
            Console.WriteLine(content);
        }
        public void PrintContent()
        {
            string Start = "[s] Start";
            string HowToPlay ="[h] How to play";
            string Exit = "[e] Exit";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Start.Length / 2)) + "}", Start));
            Console.WriteLine(" ");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (HowToPlay.Length / 2)) + "}", HowToPlay));
            Console.WriteLine(" ");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Exit.Length / 2)) + "}", Exit));
        }
        public void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("Minesweeper is a game where mines are hidden in a grid of squares.\nSafe squares have numbers telling you how many mines touch the square.\nYou can use the number clues to solve the game by opening all of the safe squares or mark all the mines.\nIf you reveal a mine you lose the game!\n\nEvery turn you have the possibility to either reveal a square or mark one wich you think is probably a mine.\nWhen you open a square that does not touch any mines, it will be empty and the adjacent squares will automatically open in all directions until reaching squares that contain numbers.\nA common strategy for starting games is to randomly click until you get a big opening with lots of numbers. \n\n");
            Console.WriteLine("\n\n\n\n\n\n\n\nPress any key to get back to the main menu.");
            Console.ReadKey();
        }
        public void ReadLine()
        {
            string input = Console.ReadLine().ToLower();
            if (input == "h")
            {
                HowToPlay();
                PrintStartScreen();
            }
            if (input == "s")
            {
                Console.Clear();
                GameIsRunning = true;
            }
            if (input == "e")
            {
                Console.Clear();
                GameIsRunning = false;
            }
        }
    }
}
