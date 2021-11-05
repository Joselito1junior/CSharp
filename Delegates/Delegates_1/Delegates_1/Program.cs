using System;
using Delegates_1.Services;

namespace Delegates_1
{
    class Program
    {
        delegate double BinaryNumericOperation(double n1, double n2);

        delegate void BinaryNumericOperationMulticast(double n1, double n2);

        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            BinaryNumericOperation op = CalculationService.Sum;
            double result = op(a, b);
            double result_1 = op.Invoke(a, b);
            Console.WriteLine(result);
            Console.WriteLine(result_1);

            //Multicast
            BinaryNumericOperationMulticast op1 = CalculationService.ShowSum;
            op1 += CalculationService.ShowMax;
            op1(a, b);
        }
    }
}
