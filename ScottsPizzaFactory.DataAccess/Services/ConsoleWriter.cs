﻿using System;

namespace ScottsPizzaFactory.DataAccess.Services
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
