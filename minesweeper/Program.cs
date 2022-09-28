using System.Text;

namespace minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Introduction.IntroMenu();

            var game = new Game();
            game.Start();

            Console.ReadLine();
        }
    }
}