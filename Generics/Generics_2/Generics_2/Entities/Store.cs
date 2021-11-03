using System;
using System.Collections.Generic;

namespace Generics_2.Entities
{
    class Store
    {
        List<Product> list = new List<Product>();

        public Store()
        {
        }

        public void AddProduct(Product prod)
        {
            list.Add(prod);
        }
        public void RemoveProduct(Product prod)
        {
            list.Remove(prod);
        }

        public List<Product> ReturnAllItens()
        {
            return list;
        }

    }
}
