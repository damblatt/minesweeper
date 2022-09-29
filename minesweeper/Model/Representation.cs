namespace minesweeper.Model
{
    internal class Representation
    {

        public string Content { get; }

        public Color Color { get; }

        private Representation(string content, Color color = Color.Default)
        {
            Content = content;
            Color = color;
        }

        public static implicit operator Representation(string value) => new Representation(value);

        public static Representation Blue(string value) => new Representation(value, Color.Blue);
        public static Representation Green(string value) => new Representation(value, Color.Green);
        public static Representation Yellow(string value) => new Representation(value, Color.Yellow);
        public static Representation Orange(string value) => new Representation(value, Color.Orange);
        public static Representation Red(string value) => new Representation(value, Color.Red);
        public static Representation Magenta(string value) => new Representation(value, Color.Magenta);

        internal void Print()
        {
            var consoleColor = Color switch
            {
                Color.Blue => ConsoleColor.Blue,
                Color.Green => ConsoleColor.Green,
                Color.Yellow => ConsoleColor.Yellow,
                Color.Orange => ConsoleColor.DarkYellow,
                Color.Red => ConsoleColor.Red,
                Color.Magenta => ConsoleColor.Magenta,
                Color.Default => ConsoleColor.White
            };

            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;

            Console.Write(Content);

            Console.ForegroundColor = prevColor;
        }
    }

    internal enum Color
    {
        Default,
        Blue,
        Green,
        Yellow,
        Orange,
        Magenta,
        Red,
    }
}
