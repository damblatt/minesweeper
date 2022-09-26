using System.Text.RegularExpressions;

namespace minesweeper
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        private static Regex _regex = new Regex("^(([a-z][1-9][1-9]?)|([1-9][1-9]?[a-z]))$");

        public static (bool, Coordinate?) TryCreateCoordinate(string input, int gridSize)
        {
            input = input.Trim().ToLower(); // Trim() cuts white-space interactors off
            // 2 or 3 characters
            if (input.Length  < 2 || input.Length > 3)
            {
                return (false, null);
            }
            
            // regex match?
            var isMatch = _regex.Match(input);
            if (!isMatch.Success)
            {
                return (false, null);
            }
            
            // detect wether the input starts with an integer or with a string
            var first = (int) input[0];
            char chr;
            string num;
            if(first > 48 && first < 58)
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

            int x = chr - 'a';
            int y = int.Parse(num) - 1;
            if (y > gridSize || y < 0)
            {
                return (false, null);
            }
            else
            {
                var coordinate = new Coordinate(x, y);
                return (true, coordinate);
            }
        }
    }
}
