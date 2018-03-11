namespace P07_CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>(n);
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(info[0], int.Parse(info[1]));

                if (info.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(info[2], out displacement))
                    {
                        engine.displacement = displacement;
                    }
                    else
                    {
                        engine.efficiency = info[2];
                    }
                }

                if (info.Length == 4)
                {
                    engine.displacement = int.Parse(info[2]);
                    engine.efficiency = info[3];
                }

                engines.Add(info[0], engine);
            }

            int m = int.Parse(Console.ReadLine());
            Car[] cars = new Car[m];
            for (int i = 0; i < m; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(info[0], engines[info[1]]);

                if (info.Length == 3)
                {
                    int weight;
                    if (int.TryParse(info[2], out weight))
                    {
                        car.weight = weight;
                    }
                    else
                    {
                        car.color = info[2];
                    }
                }

                if (info.Length == 4)
                {
                    car.weight = int.Parse(info[2]);
                    car.color = info[3];
                }

                cars[i] = car;
            }

            foreach (Car c in cars)
            {
                Console.Write(c);
            }
        }
    }
}