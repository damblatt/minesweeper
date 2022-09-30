using minesweeper.Model;

namespace minesweeper
{
    internal class ConsoleHelper
    {
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

        public int RevealOrMark(Field field)
        {
            bool inputIsCorrect = false;
            while (!inputIsCorrect)
            {
                Console.WriteLine("What do you want to do? Enter the corresponding letter");
                Console.WriteLine("[r] Reveal the fiel\n[m] Mark/unmark the field\n[c] Change field");
                var input = Console.ReadKey();


                if (input.Key == ConsoleKey.R)
                {
                    field.RevealField();
                    inputIsCorrect = true;
                    return 1;
                }
                else if (input.Key == ConsoleKey.M)
                {
                    field.MarkField();
                    inputIsCorrect = true;
                }
                else if (input.Key == ConsoleKey.C)
                {
                    inputIsCorrect = true;
                }
            }
            return 0;
        }

        public static Coordinate GetCoordinate(int gridSize)
        {
            bool isValid;
            Coordinate coordinate;
            do
            {
                (isValid, coordinate) = Coordinate.TryCreateCoordinate(Console.ReadLine(), gridSize);
            } while (!isValid);
            return coordinate;
        }
    }
}
