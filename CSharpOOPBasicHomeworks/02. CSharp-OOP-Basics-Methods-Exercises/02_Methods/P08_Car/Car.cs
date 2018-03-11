namespace P08_Car
{
    using System;

    public class Car
    {
        private readonly double speed;
        private readonly double fuelEconomy;
        private double fuel;
        private double distance;
        private double time;

        public Car(double speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy;
            this.distance = 0;
            this.time = 0;
        }

        public double Fuel
        {
            get
            {
                return this.fuel;
            }
        }

        public double Distance
        {
            get
            {
                return this.distance;
            }
        }

        public string Time
        {
            get
            {
                return this.ConvertTimeToString();
            }
        }

        public void Travel(double distanceToTravel)
        {
            double maxDistance = this.fuel / (this.fuelEconomy / 100);
            if (distanceToTravel > maxDistance)
            {
                distanceToTravel = maxDistance;
            }

            this.fuel -= distanceToTravel * (this.fuelEconomy / 100);
            this.distance += distanceToTravel;
            this.time += (distanceToTravel / this.speed) * 60;
        }

        public void Refuel(double liters)
        {
            this.fuel += liters;
        }

        private string ConvertTimeToString()
        {
            int timeTraveled = (int)Math.Floor(this.time);
            int hours = timeTraveled / 60;
            int minutes = timeTraveled % 60;
            return string.Format("{0} hours and {1} minutes", hours, minutes);
        }
    }
}