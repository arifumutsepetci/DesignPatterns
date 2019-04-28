﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager(new LoggerFactory2());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
            //burada EdLogger mı vereyim başka bir logger mı vereyim rahat karar verebiliriz. 
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

}
