using System;

namespace DelegateTask
{
    public class KeyboardHandler
    {
        public event EventHandler<char>? OnKeyPressed;

        public void Run()
        {
            char c;
            while ((c = Console.ReadKey().KeyChar) != 'c')
            {
                OnKeyPressed?.Invoke(this, c);
            }
        }
    }
}