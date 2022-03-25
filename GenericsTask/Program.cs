using System;

namespace GenericsTask
{
    class Program
    {
        private static string fileLocation = ".\\test.txt";
        public static void Main(string[] args)
        {
            var intLogger = new LocalFileLogger<int>(fileLocation);
            intLogger.LogInfo("LogInfo int test message!");
            intLogger.LogWarning("LogWarning int test message!");
            intLogger.LogError("LogWarning int test message!", 
                new Exception("Exception int test text"));
            
            var stringLogger = new LocalFileLogger<string>(fileLocation);
            stringLogger.LogInfo("LogInfo string test message!");
            stringLogger.LogWarning("LogWarning string test message!");
            stringLogger.LogError("LogWarning string test message!", 
                new Exception("Exception string test text"));
            
            var studentLogger = new LocalFileLogger<People>(fileLocation);
            studentLogger.LogInfo("LogInfo People test message!");
            studentLogger.LogWarning("LogWarning People test message!");
            studentLogger.LogError("LogWarning People test message!", 
                new Exception("Exception People test text"));
        }
    }
}