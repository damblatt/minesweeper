using System.Media;
using System.Text;

namespace minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer intro = new SoundPlayer("Resources/gameStart.wav");
            intro.Play();
            Console.Title = "Minesweeper";
            Console.ForegroundColor = ConsoleColor.White;
            Introduction.IntroMenu();
            var game = new Game();
            game.Start();

            Console.ReadLine();
        }
    }
}