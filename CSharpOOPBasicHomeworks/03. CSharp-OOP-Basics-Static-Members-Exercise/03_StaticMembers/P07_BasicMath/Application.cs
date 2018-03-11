namespace P07_BasicMath
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] info = line.Split();
                switch (info[0])
                {
                    case "Sum":
                        Console.WriteLine("{0:F2}", MathUtil.Sum(double.Parse(info[1]), double.Parse(info[2])));
                        break;
                    case "Subtract":
                        Console.WriteLine("{0:F2}", MathUtil.Subtract(double.Parse(info[1]), double.Parse(info[2])));
                        break;
                    case "Multiply":
                        Console.WriteLine("{0:F2}", MathUtil.Multiply(double.Parse(info[1]), double.Parse(info[2])));
                        break;
                    case "Divide":
                        Console.WriteLine("{0:F2}", MathUtil.Divide(double.Parse(info[1]), double.Parse(info[2])));
                        break;
                    case "Percentage":
                        Console.WriteLine("{0:F2}", MathUtil.Percentage(double.Parse(info[1]), double.Parse(info[2])));
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }

    public static class MathUtil
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double Percentage(double a, double b)
        {
            return (a / 100) * b;
        }
    }
}