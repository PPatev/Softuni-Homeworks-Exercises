namespace P07_CarSalesman
{
    using System.Text;

    public class Engine
    {
        public string model;
        public int power;
        public int displacement;
        public string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
            this.displacement = -1;
            this.efficiency = "n/a";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("  {0}:", this.model));
            result.AppendLine(string.Format("    Power: {0}", this.power));
            result.Append("    Displacement: ");
            if (this.displacement > 0)
            {
                result.AppendLine(this.displacement.ToString());
            }
            else
            {
                result.AppendLine("n/a");
            }

            result.AppendLine(string.Format("    Efficiency: {0}", this.efficiency));

            return result.ToString();
        }
    }
}

/*
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power)
            : this(model, power, -1, "n//a")
        {
        }
*/