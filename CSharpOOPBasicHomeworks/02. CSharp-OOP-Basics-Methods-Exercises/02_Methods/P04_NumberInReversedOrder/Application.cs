namespace P04_NumberInReversedOrder
{
    using System;

    public class Application
    {
        public static void Main()
        {
            DecimalNumber number = new DecimalNumber(decimal.Parse(Console.ReadLine()));
            number.PrintReverseOrder();
        }
    }
}