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
            Pathfinder consoleFridayFilePathfinder = new Pathfinder(new ConsoleFridayFilePathfinder
                (new ConsoleLogWritter(), new FridayFileLogWritter()));
        }
    }

    class FileLogWritter : ILogger
    {
        public virtual void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class ConsoleLogWritter : ILogger
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FridayFileLogWritter : FileLogWritter
    {
        public override void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                base.WriteError(message);
            }
        }
    }

    class FridayConsoleLogWritter : ConsoleLogWritter
    {
        public override void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                base.WriteError(message);
            }
        }
    }

    class ConsoleFridayFilePathfinder : ILogger
    {
        private ILogger _logger;
        private ILogger _fridayFileLogger;

        public ConsoleFridayFilePathfinder(ILogger logger, ILogger secureLogger)
        {
            _logger = logger;
            _fridayFileLogger = secureLogger;
        }

        public void WriteError(string message)
        {
            _logger.WriteError(message);
            _fridayFileLogger.WriteError(message);
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
            _logger = logger;
        }

        public void Find()
        {
            _logger.WriteError("Error");
        }
    }
}