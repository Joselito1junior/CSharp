using System;
using System.Collections.Generic;


namespace Heranca_3.Entities
{
    class IndividualPayer : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public IndividualPayer()
        {

        }

        public IndividualPayer(string name, double anualIncome, double healthExpenditures) :base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double TaxPaid()
        {
            if (AnualIncome < 20000)
            {
                return AnualIncome * 0.15;
            }
            else
            {
                return (AnualIncome * 0.25) - (HealthExpenditures * 0.5);
            }
        }
    }
}
