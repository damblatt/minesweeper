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
            bool isGameOver = false;
            while (!isGameOver)
            {
                _grid.PrintGrid();
                Console.WriteLine("Select a field you would like to REVEAL or MARK by entering it's coordinates. For example: 1A for the first field. ");

                var coordinate = ConsoleHelper.GetCoordinate(_grid.Rows);
                var selectedField = _grid.GetField(coordinate);

                //code von Damian für Coordinates
                _helper.RevealOrMark(selectedField);

                isGameOver = WinLose.WinLoseChecker(_grid);
               //selectedField.GetRepresentation();
            }
        }
    }
}