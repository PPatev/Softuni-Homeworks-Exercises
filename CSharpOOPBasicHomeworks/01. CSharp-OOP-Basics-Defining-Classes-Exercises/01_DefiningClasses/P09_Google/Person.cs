namespace P09_Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string name;
        public Company company;
        public Car car;
        public List<Pokemon> pokemons;
        public List<Parent> parents;
        public List<Child> children;

        public Person(string name)
        {
            this.name = name;
            this.company = null;
            this.car = null;
            this.pokemons = new List<Pokemon>();
            this.parents = new List<Parent>();
            this.children = new List<Child>();
        }

        public class Company
        {
            public string name;
            public string department;
            public decimal salary;

            public Company(string name, string department, decimal salary)
            {
                this.name = name;
                this.department = department;
                this.salary = salary;
            }

            public override string ToString()
            {
                return string.Format("{0} {1} {2:F2}", this.name, this.department, this.salary);
            }
        }

        public class Car
        {
            public string model;
            public int speed;

            public Car(string model, int speed)
            {
                this.model = model;
                this.speed = speed;
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", this.model, this.speed);
            }
        }

        public class Pokemon
        {
            public string name;
            public string type;

            public Pokemon(string name, string type)
            {
                this.name = name;
                this.type = type;
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", this.name, this.type);
            }
        }

        public class Parent
        {
            public string name;
            public string birthday;

            public Parent(string name, string birthday)
            {
                this.name = name;
                this.birthday = birthday;
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", this.name, this.birthday);
            }
        }

        public class Child
        {
            public string name;
            public string birthday;

            public Child(string name, string birthday)
            {
                this.name = name;
                this.birthday = birthday;
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", this.name, this.birthday);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.name);
            result.AppendLine("Company:");
            if (this.company != null)
            {
                result.AppendLine(this.company.ToString());
            }

            result.AppendLine("Car:");
            if (this.car != null)
            {
                result.AppendLine(this.car.ToString());
            }

            result.AppendLine("Pokemon:");
            foreach (Pokemon pokemon in this.pokemons)
            {
                result.AppendLine(pokemon.ToString());
            }

            result.AppendLine("Parents:");
            foreach (Parent parent in this.parents)
            {
                result.AppendLine(parent.ToString());
            }

            result.AppendLine("Children:");
            foreach (Child child in this.children)
            {
                result.AppendLine(child.ToString());
            }

            return result.ToString();
        }
    }
}