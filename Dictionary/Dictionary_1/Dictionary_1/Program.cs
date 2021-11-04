using System;
using System.IO;
using System.Collections.Generic;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votation = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(",");
                        string name = line[0];
                        int votes = int.Parse(line[1]);

                        if(votation.ContainsKey(name))
                        {
                            votation[name] += votes;
                        }
                        else
                        {
                            votation.Add(name, votes);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach(KeyValuePair<string, int> item in votation)
                Console.WriteLine(item.Key + ": " + item.Value);
        }
    }
}
