namespace P05_FibonacciNumbers
{
    using System;

    public class Application
    {
        public static void Main()
        {
            int startPosition = int.Parse(Console.ReadLine());
            int endPosition = int.Parse(Console.ReadLine());
            Fibonacci fibonacci = new Fibonacci(endPosition);
            Console.WriteLine(string.Join(", ", fibonacci.GetNumbersInRange(startPosition, endPosition)));
        }
    }
}