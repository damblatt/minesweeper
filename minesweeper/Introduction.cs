
namespace minesweeper
{
    internal class Introduction
    {
        public static ConsoleHelper helper = new ConsoleHelper();
        public static void IntroMenu()
        {
            Console.WriteLine("Welcome to Minesweeper");
            Console.WriteLine("How many columns/rows should the playing field contain? Enter a natural number between 8 and 26.");
        }
    }
}
