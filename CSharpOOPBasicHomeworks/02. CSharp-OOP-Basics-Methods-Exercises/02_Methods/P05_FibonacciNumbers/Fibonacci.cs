namespace P05_FibonacciNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class Fibonacci
    {
        private decimal[] fibonacciNumbers;

        public Fibonacci(int endPosition)
        {
            this.fibonacciNumbers = this.CalculateFibonacciNumbers(endPosition);
        }

        public List<decimal> GetNumbersInRange(int startPosition, int endPosition)
        {
            return this.fibonacciNumbers
                .Skip(startPosition)
                .Take(endPosition - startPosition)
                .ToList();
        }

        private decimal[] CalculateFibonacciNumbers(int n)
        {
            this.fibonacciNumbers = new decimal[n + 2];
            this.fibonacciNumbers[0] = 0;
            this.fibonacciNumbers[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                this.fibonacciNumbers[i] = this.fibonacciNumbers[i - 1] + this.fibonacciNumbers[i - 2];
            }

            return this.fibonacciNumbers;
        }
    }
}