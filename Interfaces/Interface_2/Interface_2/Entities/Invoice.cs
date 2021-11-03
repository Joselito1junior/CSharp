using System.Globalization;

namespace Interface_2.Entities
{
    class Invoice
    {
        public double BasicPayments { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayments, double tax)
        {
            BasicPayments = basicPayments;
            Tax = tax;
        }

        public double TotalPayment {
            get{ return BasicPayments + Tax; }
        }

        public override string ToString()
        {
            return "Basic payment: "
                + BasicPayments.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: "
                +Tax.ToString("F2", CultureInfo.InvariantCulture)
                +"\nTotal payment: "
                + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
