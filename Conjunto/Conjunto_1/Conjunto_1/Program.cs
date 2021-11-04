using System;
using System.IO;
using System.Collections.Generic;
using Conjunto_1.Entities;

namespace Conjunto_1
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<LogRecord> set = new HashSet<LogRecord>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(" ");

                        LogRecord log = new LogRecord(line[0], DateTime.Parse(line[1]));

                        set.Add(log);
                    }
                    Console.WriteLine("Total Users: " + set.Count);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
