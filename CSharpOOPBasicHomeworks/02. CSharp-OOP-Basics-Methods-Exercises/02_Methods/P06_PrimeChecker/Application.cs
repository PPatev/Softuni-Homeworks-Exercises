namespace P06_PrimeChecker
{
    using System;

    public class Application
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Number number = new Number(n);
            Console.WriteLine(number.GetNextPrimeNumber().GetNumberDetails());
        }
    }
}