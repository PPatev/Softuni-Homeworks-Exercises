namespace P01_03_Person
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        
        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int age)
            : this()
        {
            this.age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name cannot be null, empty or white space.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The age cannot negative.");
                }

                this.age = value;
            }
        }

        public int CompareTo(Person other)
        {
            return this.name.CompareTo(other.name);
        }
    }
}