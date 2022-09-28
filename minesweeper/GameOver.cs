using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class GameOver
    {
        public static void CheckGameOver(Field field, Grid _grid)
        {
            //bool isGameOver = field.UnfoldAndCheckGameOver();
            //if (isGameOver)
            {
                _grid.PrintGrid();
                PrintGameOver();
            }
        }

        public static void PrintGameOver()
        {
            Console.Clear();
            var content = File.ReadAllText("Resources/GameOverText.txt");
            Console.WriteLine(content);
            Timer.printTimerGameOver();
            return;
        }
    }
}
