namespace P06_PlanckConstant
{
    using System;

    public class Application
    {
        public static void Main()
        {
            Console.WriteLine(Calculation.Calculate());
        }
    }

    public static class Calculation
    {
        private const double PlanckConstant = 6.62606896e-34;
        private const double PiConstant = 3.14159;

        public static double Calculate()
        {
            return PlanckConstant / (2 * PiConstant);
        }
    }
}