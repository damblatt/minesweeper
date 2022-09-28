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
        private int _size;

        public Game()
        {
            _helper = new ConsoleHelper();
            _size = _helper.ReadIntMax(3, 27);
            _grid = new Grid(_size);
        }

        public void Start()
        {
            bool isGameOver = false;
            while (!isGameOver)
            {
                _grid.PrintGrid();
                Console.WriteLine("Select a field you would like to REVEAL or MARK by entering it's coordinates. For example: 1A for the first field. ");

                var coordinate = ConsoleHelper.GetCoordinate(_size);
                var selectedField = _grid.GetField(coordinate);

                //code von Damian für Coordinates
                selectedField.PrintNearbyMines();
                Console.ReadLine();
                isGameOver = _helper.RevealOrMark(selectedField);

               //selectedField.GetRepresentation();
            }
            GameOver.PrintGameOver();
        }
    }
}