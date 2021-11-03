using System;
using System.Collections.Generic;


namespace Generics_1.Entities
{
    class PrintService<T>
    {
        List<T> list = new List<T>();

        public PrintService()
        {
        }

        public void AddValue(T value)
        {
            list.Add(value);
        }

        public T First()
        {
            return list[0];
        }

        public void Print()
        {
            Console.Write("[");
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);

                if((i + 1) != list.Count)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}