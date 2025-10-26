namespace La_bataille.Models
{
    public static class ColorExtensions
    {
        public static string GetShortName(this Color color)
        {
            return color.ToString();
        }


        public static ConsoleColor GetConsoleColor(this Color color)
        {
            return color switch
            {
                Color.Coeur => ConsoleColor.Red,
                Color.Carreau => ConsoleColor.Red,
                Color.Pique => ConsoleColor.Gray,
                Color.Trèfle => ConsoleColor.Gray,
                _ => ConsoleColor.White
            };
        }
    }
}
