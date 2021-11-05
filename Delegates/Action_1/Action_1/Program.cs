using System;
using System.Collections.Generic;
using Action_1.Entities;

namespace Action_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            list.ForEach(UpdatePrice);

            foreach (Product p in list)
                Console.WriteLine(p);

            //Outra forma de fazer
            Action<Product> act = UpdatePrice;
            list.ForEach(act);

            foreach (Product p in list)
                Console.WriteLine(p);

            //Usando a função Lambda / nesse caso de uma ação é necessário utilziar as chaves para indicar que ela não retorna nada a pesar de ter um corpo
            Action<Product> act_1 = p => { p.Price += p.Price * 0.1; };
            list.ForEach(act_1);
            foreach (Product p in list)
                Console.WriteLine(p);

            //Ainda outra forma
            list.ForEach(p => { p.Price += p.Price * 0.1; });
            foreach (Product p in list)
                Console.WriteLine(p);

        }

        static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }
    }
}
