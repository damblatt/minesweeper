﻿using minesweeper.Model;

namespace minesweeper
{
    internal class Grid
    {
        private readonly int _side;
        private Field[,] _table;
        private static int _mineCount;

        public Grid(int rows)
        {
            _side = rows;
            CreateGrid();
        }

        # region Methods
        public void CreateGrid()
        {
            _table = new Field[_side, _side];
            int index = 0;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var isMine = Random.Shared.NextDouble() < 0.16;
                    if (isMine)
                    { _mineCount++;}
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

                    var left = j > 0 ? _table[i, j - 1] : null;

                    var top = i > 0 ? _table[i - 1, j] : null;

                    var right = j +1 == _table.GetLength(0) ? null : _table[i, j +1];
                    
                    var bottom = i +1 == _table.GetLength(1) ? null : _table[i +1, j];
                    
                    _table[i, j].SetFields(left, top, right, bottom);
                }
            }
        }

        public Timer SlowPrintGrid()
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
                Console.Write("  " + (x + 1).ToString("00") + " | ");

                for (int y = 0; y < _table.GetLength(1); y++)
                {
                    var field = _table[x, y];
                    var representation = field.GetRepresentation();
                    representation.Print();
                    Console.Write(" | ");
                    double waiting = ((3000 / _table.GetLength(0)) - 70) / _table.GetLength(0);
                    int waitingTime = Convert.ToInt32(waiting);
                    System.Threading.Thread.Sleep(waitingTime);
                }
                Console.WriteLine("");
                Console.Write("     -");
                for (int y = 0; y < _table.GetLength(1); y++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("");
                System.Threading.Thread.Sleep(70);
            }
            Timer timer = new Timer();
            timer.StartTimer();
            return timer;
        }

        public void PrintGrid(Timer timer)
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
                    var representation = field.GetRepresentation();
                    representation.Print();
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
            if (timer.timerIsRunning)
            {
                timer.PrintTimer();
            } else
            {
                timer.StartTimer();
            }
        }

        internal Field GetField(Coordinate coordiante)
        {
            return _table[coordiante.Y, coordiante.X];
        }

        public bool IsWon()
        {
            return IsWonByRevealed() || IsWonByMarked();
        }

        private bool IsWonByRevealed()
        {
            foreach (var field in _table)
            {
                if (!field.IsMine && !field.IsRevealed)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsWonByMarked()
        {
            foreach (var field in _table)
            {
                if (field.IsInvalidMarked)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
