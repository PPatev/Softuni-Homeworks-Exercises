namespace P01_Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            try
            {
                List<IVehicle> vehicles = new List<IVehicle>();

                string[] infoCar = Console.ReadLine()
                        .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                IVehicle car = new Car(double.Parse(infoCar[1]), double.Parse(infoCar[2]));
                vehicles.Add(car);
                
                string[] infoTruck = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                IVehicle truck = new Truck(double.Parse(infoTruck[1]), double.Parse(infoTruck[2]));
                vehicles.Add(truck);

                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] command = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (command[0])
                    {
                        case "Drive":
                            IVehicle vehicleToDrive = vehicles.FirstOrDefault(v => v.GetType().Name == command[1]);
                            Console.WriteLine(vehicleToDrive.GetDriven(double.Parse(command[2])));
                            break;
                        case "Refuel":
                            IVehicle vehicleToRefuel = vehicles.FirstOrDefault(v => v.GetType().Name == command[1]);
                            vehicleToRefuel.GetRefueled(double.Parse(command[2]));
                            break;
                    }
                }

                foreach (IVehicle vehicle in vehicles)
                {
                    Console.WriteLine("{0}: {1:F2}", vehicle.GetType().Name, vehicle.FuelQuantity);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Car : Vehicle
    {
        private const double ConsumptionCoefficient = Constants.CarConsumptionCoefficient;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double IncreaseConsumption(double consumption)
        {
            return consumption + ConsumptionCoefficient;
        }
    }

    public class Truck : Vehicle
    {
        private const double ConsumptionCoefficient = Constants.TruckConsumptionCoefficient;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double IncreaseConsumption(double consumption)
        {
            return consumption + ConsumptionCoefficient;
        }

        public override void GetRefueled(double liters)
        {
            this.FuelQuantity += liters * Constants.TruckRefuelCoefficient;
        }
    }

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                // ParameterValidator.ValidateParameter(value, "Fuel quantity");
                this.fuelQuantity = value;
            }
        }

        protected double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }

            private set
            {
                // ParameterValidator.ValidateParameter(value, "Fuel consmption");
                this.fuelConsumption = this.IncreaseConsumption(value);
            }
        }

        public string GetDriven(double kilometers)
        {
            // ParameterValidator.ValidateParameter(kilometers, "Kilometers");
            double kilometersPossible = this.FuelQuantity / this.FuelConsumption;
            if (kilometersPossible < kilometers)
            {
                return string.Format("{0} needs refueling", this.GetType().Name);
            }

            this.FuelQuantity -= this.FuelConsumption * kilometers;
            return string.Format("{0} travelled {1} km", this.GetType().Name, kilometers);
        }

        public virtual void GetRefueled(double liters)
        {
            // ParameterValidator.ValidateParameter(liters, "Fuel");
            this.FuelQuantity += liters;
        }

        public abstract double IncreaseConsumption(double consumption);
    }

    public interface IVehicle : IDrivable, IRefuelable, IConsumptionIncreasible
    {
        double FuelQuantity { get; }

        // double FuelConsumption { get; }
    }

    public interface IRefuelable
    {
        void GetRefueled(double liters);
    }

    public interface IDrivable
    {
        string GetDriven(double kilometers);
    }

    public interface IConsumptionIncreasible
    {
        double IncreaseConsumption(double coefficient);
    }

    public interface IFuelReducible
    {
        double ReduceFuel(double coefficient);
    }

    public static class Constants
    {
        public const double CarConsumptionCoefficient = 0.9;
        public const double TruckConsumptionCoefficient = 1.6;
        public const double TruckRefuelCoefficient = 0.95;
    }

    /*
    public static class ParameterValidator
    {
        public static void ValidateParameter(double parameter, string parameterName)
        {
            if (parameter < 0)
            {
                throw new ArgumentException(string.Format("{0} cannot be negative.", parameterName));
            }
        }
    }
    */
}