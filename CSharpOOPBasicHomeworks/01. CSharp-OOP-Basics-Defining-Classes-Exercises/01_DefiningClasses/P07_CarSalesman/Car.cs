namespace P07_CarSalesman
{
    using System.Text;

    public class Car
    {
        public string model;
        public Engine engine;
        public int weight;
        public string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = -1;
            this.color = "n/a";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("{0}:", this.model));
            result.Append(this.engine);
            result.Append("  Weight: ");

            if (this.weight > 0)
            {
                result.AppendLine(this.weight.ToString());
            }
            else
            {
                result.AppendLine("n/a");
            }

            result.AppendLine(string.Format("  Color: {0}", this.color));

            return result.ToString();
        }
    }
}

/*
public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, -1, "n/a")
        {
        }
*/