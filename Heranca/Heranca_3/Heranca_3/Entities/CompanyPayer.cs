using System;


namespace Heranca_3.Entities
{
    class CompanyPayer : TaxPayer
    {
        public int NumberEmployees { get; set; }

        public CompanyPayer()
        {

        }
        public CompanyPayer(string name, double anualIncome, int numberEmployees): base(name, anualIncome)
        {
            NumberEmployees = numberEmployees;
        }
        public override double TaxPaid()
        {
            return (NumberEmployees < 10) ? AnualIncome * 0.16 : AnualIncome * 0.14;
        }
    }
}
