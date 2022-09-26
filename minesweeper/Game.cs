using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Game
    {
        private ConsoleHelper _helper;
        private Grid _grid;

        public Game()
        {
            _helper = new ConsoleHelper();
            _grid = new Grid(_helper.ReadIntMax(8, 27));
        }

        public void Start()
        {
            for (int i = 0; i < 2; i++) // solange das spiel weder gewonnen noch verloren ist
            {
                _grid.PrintGrid();
                Console.WriteLine("Select a field you would like to flip by entering it's coordinates. For example: 1A for the first field. ");

                var coordinate = ConsoleHelper.GetCoordinate(_grid.Rows);
                var selectedField = _grid.GetField(coordinate);

                var isGameOver =  selectedField.UnfoldAndCheckGameOver();
                
                // char wert zum richtigen index ---> 1A = 00
            }
        }
    }
}
