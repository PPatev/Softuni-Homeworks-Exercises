namespace P04_ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string[] infoPersons = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ip in infoPersons)
            {
                string[] infoPerson = ip.Split('=');

                try
                {
                    Person person = new Person(infoPerson[0], decimal.Parse(infoPerson[1]));
                    persons[infoPerson[0]] = person;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }

            string[] infoProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ip in infoProducts)
            {
                string[] infoProduct = ip.Split('=');
                try
                {
                    Product product = new Product(infoProduct[0], decimal.Parse(infoProduct[1]));
                    products[infoProduct[0]] = product;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }

            string line = Console.ReadLine();
            while (!line.Equals("END") && !line.Equals(string.Empty))
            {
                string[] command = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (persons[command[0]].Buy(products[command[1]]))
                {
                    Console.WriteLine("{0} bought {1}", persons[command[0]], products[command[1]]);
                }
                else
                {
                    Console.WriteLine("{0} can't afford {1}", persons[command[0]], products[command[1]]);
                }

                line = Console.ReadLine();
            }

            foreach (string name in persons.Keys)
            {
                if (persons[name].Bag.Count > 0)
                {
                    Console.WriteLine("{0} - {1}", persons[name], string.Join(", ", persons[name].Bag));
                }
                else
                {
                    Console.WriteLine("{0} - Nothing bought", persons[name]);
                }
            }
        }
    }

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Bag { get; private set; }

        public bool Buy(Product product)
        {
            if (product.Cost > this.Money)
            {
                return false;
            }
            else
            {
                this.Money -= product.Cost;
                this.Bag.Add(product);
                return true;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}