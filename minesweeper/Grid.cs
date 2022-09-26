using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Grid
    {
        // Fields
        private int rows;
        private int columns;
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
        }
        public static char GetField()
        {
            // splits the user's input apart and stores it into an array
            char[] input = Console.ReadLine().ToCharArray();
            int i = 0;
            foreach (char c in input)
            {
                Console.WriteLine(input[i]);
                i++;
            }
            return input;
        }
    }
}

//foreach (char c in alpha)
//{
//    alphaSingle[i] = Convert.ToString(c);
//    //Console.WriteLine(c);
//    Console.WriteLine(alphaSingle[i]);
//    i++;
//}
