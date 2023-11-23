using System;
using System.IO;

namespace LogNapilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            Pathfinder fileLogPathfinder = new Pathfinder(new FileLogWritter());
            Pathfinder consolePathfinder = new Pathfinder(new ConsoleLogWritter());
            Pathfinder fridayFilePathfinder = new Pathfinder(new FridayFileLogWritter());
            Pathfinder fridayConsolePathfinder = new Pathfinder(new FridayConsoleLogWritter());
            Pathfinder consoleFilePathfinder = new Pathfinder(new WriteConsoleWithFileFriday
                (new ILogger[] { new ConsoleLogWritter(), new FridayFileLogWritter() }));
        }
    }

    class FileLogWritter : ILogger
    {
        private const string FileName = "log.txt";

        public virtual void WriteError(string message)
        {
            File.WriteAllText(FileName, message);
        }
    }

    class ConsoleLogWritter : ILogger
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FridayFileLogWritter : FridayLogWriter
    {
        public override void WriteError(string message)
        {
            base.WriteError(message);
        }
    }

    class FridayConsoleLogWritter : FridayLogWriter
    {
        public override void WriteError(string message)
        {
            base.WriteError(message);
        }
    }

    class FridayLogWriter : ILogger
    {
        public virtual void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                WriteError(message);
            }
        }
    }

    class WriteConsoleWithFileFriday : ILogger
    {
        private ILogger[] _loggers;

        public WriteConsoleWithFileFriday(ILogger[] loggers)
        {
            if (loggers == null)
                throw new ArgumentNullException();

            _loggers = loggers;
        }

        public void WriteError(string message)
        {
            foreach (ILogger logger in _loggers)
            {
                logger.WriteError(message);
            }
        }
    }

    interface ILogger
    {
        void WriteError(string message);
    }

    class Pathfinder
    {
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException();

            _logger = logger;
        }

        public void Find()
        {
            _logger.WriteError("Error");
        }
    }
}