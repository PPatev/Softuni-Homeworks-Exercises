namespace P05_SpeedRacing
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                decimal fuelAmount = decimal.Parse(info[1]);
                decimal fuelCost = decimal.Parse(info[2]);
                Car car = new Car(model, fuelAmount, fuelCost);
                cars.Add(model, car);
            }

            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] command = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string model = command[1];
                int kilometers = int.Parse(command[2]);
                cars[model].Drive(kilometers);
                line = Console.ReadLine();
            }

            foreach (string model in cars.Keys)
            {
                Console.WriteLine(cars[model].ToString());
            }
        }
    }
}