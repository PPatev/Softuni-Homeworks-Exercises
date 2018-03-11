namespace P04_NumberInReversedOrder
{
    using System;

    public class DecimalNumber
    {
        public decimal number;

        public DecimalNumber(decimal number)
        {
            this.number = number;
        }

        public void PrintReverseOrder()
        {
            char[] chars = this.number.ToString().ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new string(chars));
        }
    }
}