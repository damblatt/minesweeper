using System.Runtime.CompilerServices;
using System.Media;
using System.Text;

namespace minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        public static void Game()
        {
            Console.Title = "Minesweeper";
            var startScreen = new StartScreen();
            startScreen.PrintStartScreen();
            if (StartScreen.GameIsRunning)
            {
                Introduction.IntroMenu();
                var game = new Game();
                game.Start();

                Console.ReadLine();
            }
        }
    }
}