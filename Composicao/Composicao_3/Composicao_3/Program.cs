using System;
using System.Globalization;
using Composicao_3.Entities;
using Composicao_3.Entities.Enums;


namespace Composicao_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order?: ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine("Finalizou!");
                return;
            }
            else
            {
                Product prod;
                OrderItem item;

                for (int i = 1; i <= n; i++)
                {
                    item = new OrderItem();
                    prod = new Product();

                    Console.WriteLine($"Enter {i} item data:");
                    Console.Write("Product name: ");
                    prod.Name = Console.ReadLine();
                    Console.Write("Product price: ");
                    prod.Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    item.Price = prod.Price;
                    
                    Console.Write("Quantity: ");
                    item.Quantity = int.Parse(Console.ReadLine());
                    item.Product = prod;

                    order.AddItem(item);
                }
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine("Order Moment: " + order.Moment);
            Console.WriteLine("Oder Status: " + order.Status);
            Console.WriteLine("Client: " + order.Client);
            Console.WriteLine("Order items: ");

            foreach(OrderItem obj in order.Items)
                Console.WriteLine(obj);
            Console.WriteLine("Total Price: " + order.Total());

        }
    }
}
