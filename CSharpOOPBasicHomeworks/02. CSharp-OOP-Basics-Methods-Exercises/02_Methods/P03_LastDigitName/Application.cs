namespace P03_LastDigitName
{
    using System;

    public class Application
    {
        public static void Main()
        {
            Number number = new Number(int.Parse(Console.ReadLine()));
            Console.WriteLine(number.GetLastDigirName());
        }
    }
}