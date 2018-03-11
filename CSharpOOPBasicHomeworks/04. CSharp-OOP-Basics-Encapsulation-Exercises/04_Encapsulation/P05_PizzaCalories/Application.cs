namespace P05_PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            try
            {
                while (!line.Equals("END"))
                {
                    string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    switch (info[0])
                    {
                        case "Pizza":
                            Pizza pizza = CreatePizza(info[1], int.Parse(info[2]));
                            Console.WriteLine("{0} - {1:F2} Calories.", pizza.Name, pizza.Calories);
                            break;
                        case "Dough":
                            Dough dough = CreateDough(info[1], info[2], double.Parse(info[3]));
                            Console.WriteLine("{0:F2}", dough.Calories);
                            break;
                        case "Topping":
                            Topping topping = CreateTopping(info[1], double.Parse(info[2]));
                            Console.WriteLine("{0:F2}", topping.Calories);
                            break;
                    }

                    line = Console.ReadLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Pizza CreatePizza(string name, int numberOfToppings)
        {
            Pizza pizza = new Pizza(name, numberOfToppings);

            string[] infoDough = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Dough pizzaDough = CreateDough(infoDough[1], infoDough[2], double.Parse(infoDough[3]));
            pizza.PizzaDough = pizzaDough;

            for (int i = 0; i < pizza.NumberOfToppings; i++)
            {
                string[] infoTopping = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Topping pizzaTopping = CreateTopping(infoTopping[1], double.Parse(infoTopping[2]));
                pizza.AddTopping(pizzaTopping);
            }

            return pizza;
        }

        private static Dough CreateDough(string flourType, string bakingTechnique, double weight)
        {
            return new Dough(flourType, bakingTechnique, weight);
        }

        private static Topping CreateTopping(string type, double weight)
        {
            return new Topping(type, weight);
        }
    }

    internal class Pizza
    {
        private string name;
        private int numberOfToppings;
        private List<Topping> toppings;

        internal Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;
            this.toppings = new List<Topping>(numberOfToppings);
        }

        internal string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        internal int NumberOfToppings
        {
            get
            {
                return this.numberOfToppings;
            }

            private set
            {
                if (value < 1 || 10 < value)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        internal double Calories
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        internal Dough PizzaDough { private get; set; }

        internal void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        private double CalculateCalories()
        {
            double calories = this.PizzaDough.Calories;

            foreach (Topping topping in this.toppings)
            {
                calories += topping.Calories;
            }

            return calories;
        }
    }

    internal class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        internal Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.Calories = this.CalculateCalories();
        }

        internal double Calories { get; private set; }

        private string FlourType
        {
            set
            {
                if (!value.ToLower().Equals("white") && !value.ToLower().Equals("wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!value.ToLower().Equals("crispy") && !value.ToLower().Equals("chewy") && !value.ToLower().Equals("homemade"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || 200 < value)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private double CalculateCalories()
        {
            double calories = this.weight * 2;

            switch (this.flourType.ToLower())
            {
                case "white":
                    calories *= 1.5;
                    break;
                case "wholegrain":
                    calories *= 1.0;
                    break;
            }

            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    calories *= 0.9;
                    break;
                case "chewy":
                    calories *= 1.1;
                    break;
                case "homemade":
                    calories *= 1.0;
                    break;
            }

            return calories;
        }
    }

    internal class Topping
    {
        private string type;
        private double weight;

        internal Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
            this.Calories = this.CalculateCalories();
        }

        internal double Calories { get; private set; }

        private string Type
        {
            set
            {
                if (!value.ToLower().Equals("meat")
                    && !value.ToLower().Equals("veggies")
                    && !value.ToLower().Equals("cheese")
                    && !value.ToLower().Equals("sauce"))
                {
                    throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
                }

                this.type = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || 50 < value)
                {
                    throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", this.type));
                }

                this.weight = value;
            }
        }

        private double CalculateCalories()
        {
            double calories = this.weight * 2;

            switch (this.type.ToLower())
            {
                case "meat":
                    calories *= 1.2;
                    break;
                case "veggies":
                    calories *= 0.8;
                    break;
                case "cheese":
                    calories *= 1.1;
                    break;
                case "sauce":
                    calories *= 0.9;
                    break;
            }

            return calories;
        }
    }
}

/*
namespace P05_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("END"))
            {
                string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                switch (info[0])
                {
                    case "Pizza":
                        Pizza pizza = CreatePizza(info[1], int.Parse(info[2]));
                        Console.WriteLine("{0} – {1:F2} Calories.", pizza.Name, pizza.Calories);
                        break;
                    case "Dough":
                        Dough dough = CreateDough(info[1], info[2], double.Parse(info[3]));
                        Console.WriteLine("{0:F2}", dough.Calories);
                        break;
                    case "Topping":
                        Topping topping = CreateTopping(info[1], double.Parse(info[2]));
                        Console.WriteLine("{0:F2}", topping.Calories);
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static Pizza CreatePizza(string name, int numberOfToppings)
        {
            Pizza pizza = null;
            try
            {
                pizza = new Pizza(name, numberOfToppings);

                string[] infoDough = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Dough pizzaDough = CreateDough(infoDough[1], infoDough[2], double.Parse(infoDough[3]));
                pizza.PizzaDough = pizzaDough;

                for (int i = 0; i < pizza.NumberOfToppings; i++)
                {
                    string[] infoTopping = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    Topping pizzaTopping = CreateTopping(infoTopping[1], double.Parse(infoTopping[2]));
                    pizza.AddTopping(pizzaTopping);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            return pizza;
        }

        private static Dough CreateDough(string flourType, string bakingTechnique, double weight)
        {
            Dough dough = null;
            try
            {
               dough = new Dough(flourType, bakingTechnique, weight);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            return dough;
        }

        private static Topping CreateTopping(string type, double weight)
        {
            Topping topping = null;
            try
            {
                topping = new Topping(type, weight);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            return topping;
        }
    }

    internal class Pizza
    {
        private string name;
        private int numberOfToppings;
        private List<Topping> toppings;

        internal Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;
            this.toppings = new List<Topping>(numberOfToppings);
        }

        internal string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        internal int NumberOfToppings
        {
            get
            {
                return this.numberOfToppings;
            }

            private set
            {
                if (value < 1 || 10 < value)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        internal double Calories
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        internal Dough PizzaDough { private get; set; }

        internal void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        private double CalculateCalories()
        {
            double calories = this.PizzaDough.Calories;

            foreach (Topping topping in this.toppings)
            {
                calories += topping.Calories;
            }

            return calories;
        }
    }

    internal class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        internal Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.Calories = this.CalculateCalories();
        }

        internal double Calories { get; private set; }

        private string FlourType
        {
            set
            {
                if (!value.ToLower().Equals("white") && !value.ToLower().Equals("wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!value.ToLower().Equals("crispy") && !value.ToLower().Equals("chewy") && !value.ToLower().Equals("homemade"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || 200 < value)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private double CalculateCalories()
        {
            double calories = this.weight * 2;

            switch (this.flourType.ToLower())
            {
                case "white":
                    calories *= 1.5;
                    break;
                case "wholegrain":
                    calories *= 1.0;
                    break;
            }

            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    calories *= 0.9;
                    break;
                case "chewy":
                    calories *= 1.1;
                    break;
                case "homemade":
                    calories *= 1.0;
                    break;
            }
           
            return calories;
        }
    }

    internal class Topping
    {
        private string type;
        private double weight;

        internal Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
            this.Calories = this.CalculateCalories();
        }

        public double Calories { get; private set; }

        private string Type
        {
            set
            {
                if (!value.ToLower().Equals("meat")
                    && !value.ToLower().Equals("veggies")
                    && !value.ToLower().Equals("cheese")
                    && !value.ToLower().Equals("sauce"))
                {
                    throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
                }

                this.type = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || 50 < value)
                {
                    throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", this.type));
                }

                this.weight = value;
            }
        }

        private double CalculateCalories()
        {
            double calories = this.weight * 2;

            switch (this.type.ToLower())
            {
                case "meat":
                    calories *= 1.2;
                    break;
                case "veggies":
                    calories *= 0.8;
                    break;
                case "cheese":
                    calories *= 1.1;
                    break;
                case "sauce":
                    calories *= 0.9;
                    break;
            }

            return calories;
        }
    }
}
*/