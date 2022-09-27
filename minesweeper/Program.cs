using System.Text;

namespace minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction.IntroMenu();

            var game = new Game();
            game.Start();


            Console.ReadLine();
        }
    }
}