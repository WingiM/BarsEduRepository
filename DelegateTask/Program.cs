using System;

namespace DelegateTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            var keyHandler = new KeyboardHandler();
            keyHandler.OnKeyPressed += ProcessChar;
            keyHandler.Run();
        }

        private static void ProcessChar(object? sender, char c)
        {
            Console.WriteLine(c);
        }
    }
}