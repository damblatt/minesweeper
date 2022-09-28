using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Grid
    {
        private ConsoleHelper _helper = new ConsoleHelper();
        public Coordinate _neighbour;

        // Fields
        private readonly int _rows;
        private readonly int _columns;
        private Field[,] _table;
        // Properties
        //public int Rows
        //{
        //    get { return rows; }
        //    set;
        //}
        //public int Columns
        //{
        //    get { return rows; }
        //    set { columns = Rows; }
        //}

        public Field[,] Table { get; set; }

        // Constructor
        public Grid(int rows)
        {
            _rows = rows;
            _columns = rows;
            CreateGrid();
        }

        // Methods
        public void CreateGrid()
        {
            _table = new Field[_rows, _columns];
            int index = 0;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var isMine = Random.Shared.NextDouble() < 0.16;
                    _table[i, j] = new Field(index , isMine);
                    index++;
                }
            }

            GetNearbyStats();
        }

        public void GetNearbyStats()
        {
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var current = _table[i, j];

                    var left = j - 1 > 0 ? _table[i, j - 1] : null;
                    //bool isVerified = VerifyCoordinate(i, j - 1);
                    //if (isVerified)
                    //{
                    //    var left = _table[i, j - 1];
                    //}

                    var top = i - 1 > 0 ? _table[i - 1, j] : null;
                    //isVerified = VerifyCoordinate(i - 1, j);
                    //if (isVerified)
                    //{
                    //    top = _table[i -1, j];
                    //}

                    var right = j +1 == _table.GetLength(0) ? null : _table[i, j +1];
                    //isVerified = VerifyCoordinate(i, j +1);
                    //if (isVerified)
                    //{
                    //    right = _table[i, j + 1];
                    //}

                    var bottom = i +1 == _table.GetLength(1) ? null : _table[i +1, j];
                    //isVerified = VerifyCoordinate(i +1, j);
                    //if (isVerified)
                    //{
                    //    bottom = _table[i + 1, j];
                    //}

                    _table[i, j].SetFields(left, top, right, bottom);
                    int minesNearby = _table[i, j].MinesArroundMe();
                    _table[i, j].SetMinesNearby(minesNearby);
                }
            }
            //foreach(var field in _table)
            //{
            //    field.SetFields(left, top, right, bottom);
            //    int minesNearby = field.MinesArroundMe();
            //    field.SetMinesNearby(minesNearby);
            //}
        }

        private bool VerifyCoordinate(int y, int x)
        {
            return !(y < 0 || y >= _rows || x < 0 || x >= _columns);

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
                    Console.Write(field.GetRepresentation());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | ");
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
    }
}
