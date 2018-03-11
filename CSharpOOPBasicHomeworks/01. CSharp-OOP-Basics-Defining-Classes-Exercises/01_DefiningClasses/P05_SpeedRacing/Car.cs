namespace P05_SpeedRacing
{
    using System;

    public class Car
    {
        public string model;
        public decimal fuelAmount;
        public decimal fuelCost;
        public int distanceTraveled;

        public Car(string model, decimal fuelAmount, decimal fuelCost)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelCost = fuelCost;
            this.distanceTraveled = 0;
        }

        public void Drive(int kilometers)
        {
            if (this.fuelCost * kilometers > this.fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.fuelAmount -= this.fuelCost * kilometers;
            this.distanceTraveled += kilometers;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:F2} {2}", this.model, this.fuelAmount,this.distanceTraveled);
        }
    }
}