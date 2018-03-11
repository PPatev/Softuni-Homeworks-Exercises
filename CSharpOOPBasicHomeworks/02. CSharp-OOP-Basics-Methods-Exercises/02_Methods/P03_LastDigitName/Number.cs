namespace P03_LastDigitName
{
    using Microsoft.Win32.SafeHandles;

    public class Number
    {
        public int number;
        private static string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public Number(int number)
        {
            this.number = number;
        }

        public string GetLastDigirName()
        {
            return words[this.number % 10];
        }
    }
}