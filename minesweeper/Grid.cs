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
            int index = 0;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var isMine = Random.Shared.NextDouble() < 0.5; // random value // current mine rate = 50%
                    _table[i, j] = new Field(index , isMine);
                }
            }

            //GetNearbyStats();
        }

        public void GetNearbyStats()
        {
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var current = _table[i, j];
                    Field? left = null;
                    Field? top = null;
                    Field? right = null;
                    Field? bottom = null;

                    // left
                    bool isVerified = _helper.VerifyCoordinate(i, j - 1, Rows);
                    if (isVerified)
                    {
                        left = _table[i, j - 1];
                    }

                    // top
                    isVerified = _helper.VerifyCoordinate(i - 1, j, Rows);
                    if (isVerified)
                    {
                        top = _table[i -1, j];
                    }

                    // right
                    isVerified = _helper.VerifyCoordinate(i, j +1, Rows);
                    if (isVerified)
                    {
                        right = _table[i, j + 1];
                    }

                    // bottom
                    isVerified = _helper.VerifyCoordinate(i +1, j, Rows);
                    if (isVerified)
                    {
                        bottom = _table[i + 1, j];
                    }

                    current.SetFields(left, top, right, bottom);
                    int minesNearby = current.MinesArroundMe();
                    current.SetMinesNearby(minesNearby);
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
    }
}
