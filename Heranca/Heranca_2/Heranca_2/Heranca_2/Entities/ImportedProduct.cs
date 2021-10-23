using System.Globalization;

namespace Heranca_2.Entities
{
    class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct()
        {

        }
        public ImportedProduct(string name, double price, double customsFee) : base(name, price)
        {
            CustomsFee = customsFee;
        }
        public sealed override string PriceTag()
        {
            return Name
                +" $ "
                + TotalPrice().ToString("F2", CultureInfo.InvariantCulture)
                + $"(Customs fee: ${CustomsFee})";
        }
        public double TotalPrice()
        {
            return Price + CustomsFee;
        }
    }
}
