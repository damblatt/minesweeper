﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using minesweeper.Model;

namespace minesweeper
{
    internal class Grid
    {
        private ConsoleHelper _helper = new ConsoleHelper();

        // Fields
        private readonly int _rows;
        private readonly int _columns;
        private Field[,] _table;
        public static int MineCount;
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

        # region Methods
        // Methods
        public void CreateGrid()
        {
            _table = new Field[_rows, _columns];
            int index = 0;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var isMine = Random.Shared.NextDouble() < 0.1;
                    if (isMine)
                    { MineCount++;}
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

        public bool IsWon()
        {
            return IsWonByRevealed() || IsWonByMarked();
        }

        private bool IsWonByRevealed()
        {
            return false;
        }

        public bool IsWonByMarked()
        {
            foreach (var field in _table)
            {
                if (!field.IsMineAndMarkedOrRevealed())
                {
                    return false;
                }
            }
            return true;
        }

        public static void FlipNearbyFields(Field field)
        {
            if (field.Top.Left != null)
            {
                field.Top.Left.RevealField();
            }

            if (field.Top != null)
            {
                field.Top.RevealField();
            }

            if (field.Top.Right != null)
            {
                field.Top.Right.RevealField();
            }

            if (field.Right != null)
            {
                field.Right.RevealField();
            }

            if (field.Bottom.Right != null)
            {
                field.Bottom.Right.RevealField();
            }

            if (field.Bottom != null)
            {
                field.Bottom.RevealField();
            }

            if (field.Bottom.Left != null)
            {
                field.Bottom.Left.RevealField();
            }

            if (field.Left != null)
            {
                field.Left.RevealField();
            }
        }

        #endregion
    }
}
