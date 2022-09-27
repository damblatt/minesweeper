using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Grid
    {
        private ConsoleHelper _helper;
        private Grid _grid;

        // Fields
        private int rows;
        int columns;
        private Field[,] _table;
        // Properties
        public int Rows
        {
            get { return rows; }
            set
            {
                if (value > 26 || value < 8)
                {
                    rows = 8;
                }
                else { rows = value; }
            }
        }
        public int Columns
        {
            get { return rows; }
            set { columns = Rows; }
        }

        public Field[,] Table { get; set; }

        // Constructor
        public Grid(int rows)
        {
            this.Rows = rows;
            this.Columns = rows;
            CreateGrid();
        }

        // Methods
        public void CreateGrid()
        {
            _table = new Field[Rows, Columns];
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var isBomb = Random.Shared.NextDouble() < 0.16; // random value
                    _table[i, j] = new Field(isBomb);
                }
            }
        }

        public void PrintGrid()
        {
            Console.Clear();
            Console.WriteLine();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int i = 0;
            Console.Write("     ");
            for (i = 0; i < _table.GetLength(1); i++)
            {
                Console.Write("  " + alpha[i] + " ");
            }
            
            Console.WriteLine();
            Console.Write("     -");
            for (int y = 0; y < _table.GetLength(1); y++)
            {
                Console.Write("----");
            }
            Console.WriteLine("");
            for (int x = 0; x < _table.GetLength(0); x++)
            {
                Console.Write("  " + (x +1).ToString("00") + " | ");
                for (int y = 0; y < _table.GetLength(1); y++)
                {
                    var field = _table[x, y];
                    Console.Write(field.GetRepresentation() + " | ");
                }
                Console.WriteLine("");
                Console.Write("     -");
                for(int y = 0; y < _table.GetLength(1); y++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("");
            }
            if (Timer.timerIsRunning)
            {
                Timer.printTimer();
            } else
            {
                Timer.timerStarter();
            }
        }

        internal Field GetField(Coordinate coordiante)
        {
            return _table[coordiante.Y, coordiante.X];
        }

        public void GetNeighbourStats(Coordinate coordinate)
        {
            List<Coordinate> _neighbourFields = new List<Coordinate> ();
            //var coordinate = ConsoleHelper.GetCoordinate(_grid.Rows);
            //var selectedField = _grid.GetField(coordinate);
            bool isVerified;
            bool isGameOver;

            // top left
            coordinate.Y--;
            coordinate.X--;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var topLeftCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(topLeftCoordinate);
                _neighbourFields.Add(topLeftCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }

            // top
            coordinate.X++;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified) 
            {
                var topCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(topCoordinate);
                _neighbourFields.Add(topCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }

            // top right
            coordinate.X++;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var topRightCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(topRightCoordinate);
                _neighbourFields.Add(topRightCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }

            // right
            coordinate.Y++;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var rightCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(rightCoordinate);
                _neighbourFields.Add(rightCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }

            // bottom right
            coordinate.Y++;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var bottomRightCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(bottomRightCoordinate);
                _neighbourFields.Add(bottomRightCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }
            
            // bottom
            coordinate.X--;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var bottomCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(bottomCoordinate);
                _neighbourFields.Add(bottomCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }
            
            // bottom left
            coordinate.X--;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var bottomLeftCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(bottomLeftCoordinate);
                _neighbourFields.Add(bottomLeftCoordinate);
                GameOver.CheckGameOver(field, _grid);
                if (!field.IsMine)
                {
                    field.UnfoldAndCheckGameOver();
                }
            }

            // left
            coordinate.Y--;
            coordinate.X -= 2;
            isVerified = _helper.VerifyCoordinate(coordinate.Y, coordinate.X, Rows);
            if (isVerified)
            {
                var leftCoordinate = new Coordinate(coordinate.Y, coordinate.X);
                var field = _grid.GetField(leftCoordinate);
                _neighbourFields.Add(leftCoordinate);
                GameOver.CheckGameOver(field, _grid);
            }
        }
    }
}
