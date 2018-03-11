namespace P02_VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P01_Vehicles;

    public class Application
    {
        public static void Main()
        {
            List<VehicleExtended> vehicles = new List<VehicleExtended>();

            try
            {
                string[] infoCar = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                VehicleExtended car = new Car(
                    double.Parse(infoCar[1]),
                    double.Parse(infoCar[2]),
                    double.Parse(infoCar[3]));
                vehicles.Add(car);

                string[] infoTruck = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                VehicleExtended truck = new Truck(
                    double.Parse(infoTruck[1]),
                    double.Parse(infoTruck[2]),
                    double.Parse(infoTruck[3]));
                vehicles.Add(truck);

                string[] infoBus = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                VehicleExtended bus = new Bus(
                    double.Parse(infoBus[1]),
                    double.Parse(infoBus[2]),
                    double.Parse(infoBus[3]));
                vehicles.Add(bus);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] command = Console.ReadLine()
                        .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (command[0])
                    {
                        case "Drive":
                            VehicleExtended vehicleToDrive = vehicles.FirstOrDefault(v => v.GetType().Name == command[1]);
                            Console.WriteLine(vehicleToDrive.GetDriven(double.Parse(command[2])));
                            break;
                        case "DriveEmpty":
                            VehicleExtended vehicleToDriveEmpty = vehicles.FirstOrDefault(v => v.GetType().Name == command[1]);
                            Console.WriteLine(vehicleToDriveEmpty.GetDrivenEmpty(double.Parse(command[2])));
                            break;
                        case "Refuel":
                            VehicleExtended vehicleToRefuel = vehicles.FirstOrDefault(v => v.GetType().Name == command[1]);
                            vehicleToRefuel.GetRefueled(double.Parse(command[2]));
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine("{0}: {1:F2}", vehicle.GetType().Name, vehicle.FuelQuantity);
            }
        }
    }

    public class Bus : VehicleExtended
    {
        private const double ConsumptionCoefficient = 1.4;

        private double fuelConsumptionOriginal;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.fuelConsumptionOriginal = fuelConsumption;
        }

        public override double IncreaseConsumption(double consumption)
        {
            return consumption + ConsumptionCoefficient;
        }

        public override string GetDrivenEmpty(double kilometers)
        {
            // ParameterValidator.ValidateParameter(kilometers, "Kilometers");
            double kilometersPossible = this.FuelQuantity / this.fuelConsumptionOriginal;
            if (kilometersPossible < kilometers)
            {
                return string.Format("{0} needs refueling", this.GetType().Name);
            }

            this.FuelQuantity -= this.fuelConsumptionOriginal * kilometers;
            return string.Format("{0} travelled {1} km", this.GetType().Name, kilometers);
        }
    }

    public class Car : VehicleExtended
    {
        private const double ConsumptionCoefficient = Constants.CarConsumptionCoefficient;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double IncreaseConsumption(double consumption)
        {
            return consumption + ConsumptionCoefficient;
        }

        public override string GetDrivenEmpty(double kilometers)
        {
            return null;
        }
    }

    public class Truck : VehicleExtended
    {
        private const double ConsumptionCoefficient = Constants.TruckConsumptionCoefficient;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
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

        public override string GetDrivenEmpty(double kilometers)
        {
            return null;
        }
    }

    public abstract class VehicleExtended : Vehicle
    {
        private double tankCapacity;

        protected VehicleExtended(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.tankCapacity = value;
            }
        }

        public override void GetRefueled(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }

            base.GetRefueled(liters);
        }

        public abstract string GetDrivenEmpty(double kilometers);
    }
}