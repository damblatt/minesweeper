using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class ConsoleHelper
    {
        /// <summary>
        /// ReadInt
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="instructionMessage">Message if the user's input is invalid</param>
        /// <returns></returns>
        public int ReadInt(int min, string instructionMessage = "")
        {
            string? input;
            int n;
            bool criteria;
            while (criteria = (!Int32.TryParse(input = Console.ReadLine(), out n) || n < min))
            {
                if (instructionMessage == "" || criteria) { instructionMessage = $"{input} is an invalid number.\nPlease enter a valid number: "; }
                Console.Write(instructionMessage);
            }
            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <param name="instructionMessage">Message if the user's input is invalid</param>
        /// <returns></returns>
        public int ReadIntMax(int min, int max, string instructionMessage = "")
        {
            string? input;
            int n;
            bool criteria;
            while (criteria = (!Int32.TryParse(input = Console.ReadLine(), out n) || n < min || n >= max))
            {
                if (instructionMessage == "" || criteria) { instructionMessage = $"{input} is an invalid number.\nPlease enter a valid number ({min} - {max - 1}): "; }
                Console.Write(instructionMessage);
            }
            return n;
        }


        public static Coordinate GetCoordinate(int gridSize)
        {
            //// splits the user's input apart and stores it into an array
            //char[] input = Console.ReadLine().ToCharArray();
            //return input;
            bool isValid;
            Coordinate coordinate;
            do
            {
                (isValid, coordinate) = Coordinate.TryCreateCoordinate(Console.ReadLine(), gridSize);
            } while (!isValid);
            return coordinate;
        }

        public bool VerifyCoordinate(int y, int x, int gridSize)
        {
            bool isVerified;
            if (y < 0 || y > gridSize || x < 0 | x > gridSize)
            {
                return isVerified = false;
            }
            return isVerified = true;
        }
    }
}
