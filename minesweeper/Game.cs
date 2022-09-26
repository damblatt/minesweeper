using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Game
    {
        public static ConsoleHelper helper = new ConsoleHelper();
        public static Grid grid = new Grid(helper.ReadIntMax(8, 27));
        public static void MainLoop()
        {
            for (int i = 0; i < 2; i++) // solange das spiel weder gewonnen noch verloren ist
            {
                grid.PrintGrid();
                Console.WriteLine("Select a field you would like to flip by entering it's coordinates. For example: 1A for the first field. ");
                var selectedField = grid.GetField();
                foreach (char c in selectedField)
                {
                    Console.WriteLine(c);
                }

                char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] num = {'1', '2', '3'}
                selectedField[0]
                // char wert zum richtigen index ---> 1A = 00
                grid._table[1, 1].UnfoldAndCheckGameOver();
            }
        }
    }
}
