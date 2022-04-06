using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadTask
{
    class Program
    {
        private static readonly DummyRequestHandler RequestHandler =
            new DummyRequestHandler();

        public static void Main(string[] args)
        {
            Console.WriteLine("Введите текст запроса для отправки. " +
                              "Для выхода введите /exit");
            string command;
            while ((command = Console.ReadLine()) != "/exit")
            {
                CreateRequest(command);
                Console.WriteLine("Введите текст запроса для отправки. " +
                                  "Для выхода введите /exit");
            }

            Console.WriteLine("Конец работы");
        }

        private static void CreateRequest(string message)
        {
            Console.WriteLine($"Будет послано сообщение {message}");
            Console.WriteLine(
                "Введите аргументы сообщения. Если аргументы не нужны " +
                "- введите /end");
            var args = new List<string>();

            string argument;
            while ((argument = Console.ReadLine()) != "/end")
            {
                args.Add(argument);
                Console.WriteLine("Введите следующий аргумент сообщения. " +
                                  "Для окончания добавления " +
                                  "аргументов введите /end");
            }

            var id = Guid.NewGuid().ToString("D");
            Console.WriteLine($"Было отправлено сообщение \"{message}\". " +
                              $"Присвоен идентификатор {id}");
            ThreadPool.QueueUserWorkItem(_ =>
                HandleRequest(id, message, args.ToArray()));
        }

        private static void HandleRequest(string id, string message,
            string[] args)
        {
            try
            {
                var response = RequestHandler.HandleRequest(message, args);
                Console.WriteLine($"Сообщение с идентификатором {id} " +
                                  $"получило ответ - {response}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Сообщение с идентификатором {id} " +
                                  $"упало с ошибкой: {e.Message}");
            }
        }
    }
}