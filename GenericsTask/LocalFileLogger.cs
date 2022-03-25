using System;
using System.IO;

namespace GenericsTask
{
    public class LocalFileLogger<T> : ILogger
    {
        private readonly string _fileLocation;
        
        public LocalFileLogger(string fileLocation)
        {
            this._fileLocation = fileLocation;
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(_fileLocation, $"[Info]: [{typeof(T).Name}] : {message}" + '\n');
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(_fileLocation, $"[Warning] : [{typeof(T).Name}] : {message}" + '\n');
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(_fileLocation, $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}" + '\n');
        }
    }
}