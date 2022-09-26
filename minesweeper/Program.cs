using System.Text;

namespace minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction.IntroMenu();
            Game.MainLoop();

            Console.ReadLine();
        }
    }
}