namespace P06_PrimeChecker
{
    using System;

    public class Number
    {
        public long number;
        public bool prime;

        public Number(long number, bool prime)
        {
            this.number = number;
            this.prime = prime;
        }

        public Number(long number)
        {
            this.number = number;
            this.prime = this.CheckIfPrime(number);
        }

        public Number GetNextPrimeNumber()
        {
            return new Number(this.FindNextPrime(this.number), this.prime);
        }

        public string GetNumberDetails()
        {
            return string.Format("{0}, {1}", this.number, this.prime.ToString().ToLower());
        }

        private bool CheckIfPrime(long n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private long FindNextPrime(long n)
        {
            for (long i = n + 1; i <= (2 * n) + 1; i++)
            {
                if (this.CheckIfPrime(i))
                {
                    return i;
                }
            }

            return 0;
        }
    }
}