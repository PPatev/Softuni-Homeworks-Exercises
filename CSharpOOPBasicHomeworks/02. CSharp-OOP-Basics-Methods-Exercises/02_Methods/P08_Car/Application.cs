namespace P08_Car
{
    using System;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            double[] info = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Car car = new Car(info[0], info[1], info[2]);
            string line = Console.ReadLine();
            while (!line.Equals("END"))
            {
                string[] command = line.Split();
                switch (command[0])
                {
                    case "Travel":
                        car.Travel(double.Parse(command[1]));
                        break;
                    case "Refuel":
                        car.Refuel(double.Parse(command[1]));
                        break;
                    case "Distance":
                        Console.WriteLine("Total distance: {0:F1} kilometers", car.Distance);
                        break;
                    case "Time":
                        Console.WriteLine("Total time: {0}", car.Time);
                        break;
                    case "Fuel":
                        Console.WriteLine("Fuel left: {0:F1} liters", car.Fuel);
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}