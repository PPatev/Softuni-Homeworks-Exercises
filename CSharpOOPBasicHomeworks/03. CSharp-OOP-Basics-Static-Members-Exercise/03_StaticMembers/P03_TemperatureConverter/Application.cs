namespace P03_TemperatureConverter
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
                switch (info[1])
                {
                    case "Celsius":
                        Console.WriteLine("{0:F2} Fahrenheit", TemperatureConverter.ConvertCelsiusToFahrenheit(int.Parse(info[0])));
                        break;
                    case "Fahrenheit":
                        Console.WriteLine("{0:F2} Celsius", TemperatureConverter.ConvertFahrenheitToCelsius(int.Parse(info[0])));
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }

    public static class TemperatureConverter
    {
        public static double ConvertCelsiusToFahrenheit(int degrees)
        {
            return (degrees * 1.8) + 32;
        }

        public static double ConvertFahrenheitToCelsius(int degrees)
        {
            return (degrees - 32) / 1.8;
        }
    }
}