
using System.Media;

namespace minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var intro = new SoundPlayer("Resources/gameStart.wav");
            intro.PlaySync();
            Game();
        }

        public static void Game()
        {
            var main = new SoundPlayer("Resources/main.wav");
            main.PlayLooping();
            Console.Title = "Minesweeper";
            var startScreen = new StartScreen();
            startScreen.PrintStartScreen();
            if (StartScreen.GameIsRunning)
            {
                Introduction.IntroMenu();
                WinLose.IsLost = false;
                var game = new Game();
                game.Start();

                Console.ReadLine();
            }
        }
    }
}