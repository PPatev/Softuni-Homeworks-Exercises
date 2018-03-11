namespace P06_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                double tire1Pressure = double.Parse(info[5]);
                int tire1Age = int.Parse(info[6]);
                double tire2Pressure = double.Parse(info[7]);
                int tire2Age = int.Parse(info[8]);
                double tire3Pressure = double.Parse(info[9]);
                int tire3Age = int.Parse(info[10]);
                double tire4Pressure = double.Parse(info[11]);
                int tire4Age = int.Parse(info[12]);
                Car car = new Car(
                    model,
                    engineSpeed,
                    enginePower,
                    cargoWeight,
                    cargoType,
                    tire1Pressure,
                    tire1Age,
                    tire2Pressure,
                    tire2Age,
                    tire3Pressure,
                    tire3Age,
                    tire4Pressure,
                    tire4Age);
                cars.Add(car);
            }

            switch (Console.ReadLine())
            {
                case "fragile":
                    List<Car> fragileCargo = cars
                        .Where(c => c.cargo.cargoType.Equals("fragile")
                            && c.tires.Any(t => t.tirePressure < 1))
                            .ToList();
                    Console.WriteLine(string.Join(Environment.NewLine, fragileCargo));
                    break;
                case "flamable":
                    List<Car> flamableCargo = cars
                        .Where(c => c.cargo.cargoType.Equals("flamable")
                            && c.engine.enginePower > 250)
                            .ToList();
                    Console.WriteLine(string.Join(Environment.NewLine, flamableCargo));
                    break;
                default:
                    break;
            }
        }
    }
}