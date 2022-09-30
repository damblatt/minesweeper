using System.Text.RegularExpressions;

namespace minesweeper.Model
{
    public class Coordinate
    {
        private static Regex _regex = new Regex("^(([a-z][0-9][0-9]?)|([0-9][0-9]?[a-z]))$");

        public int Y { get; }
        public int X { get; }

        public Coordinate(int y, int x)
        {
            Y = y;
            X = x;
        }

        public static (bool, Coordinate?) TryCreateCoordinate(string input, int gridSize)
        {
            input = input.Trim().ToLower(); // Trim() cuts white-space interactors off
            if (input.Length < 2 || input.Length > 3)
            {
                Console.Write("This field does not exist. Enter a valid coordinate: ");
                return (false, null);
            }

            var isMatch = _regex.Match(input);
            if (!isMatch.Success)
            {
                Console.Write("This field does not exist. Enter a valid coordinate: ");
                return (false, null);
            }

            // detect wether the input starts with an integer or with a string
            var first = (int)input[0];
            char chr;
            string num;
            if (first > 48 && first < 58)
            {
                // first is digit
                chr = input[^1];
                num = input[..^1];
            }
            else
            {
                // first is chr
                chr = input[0];
                num = input[1..];
            }

            int y = int.Parse(num) - 1;
            int x = chr - 'a';
            if (y >= gridSize || y < 0)
            {
                Console.Write("This field does not exist. Enter a valid coordinate: ");
                return (false, null);
            }
            if (x >= gridSize || x < 0)
            {
                Console.Write("This field does not exist. Enter a valid coordinate: ");
                return (false, null);
            }
            else
            {
                var coordinate = new Coordinate(y, x);
                return (true, coordinate);
            }
        }
    }
}
