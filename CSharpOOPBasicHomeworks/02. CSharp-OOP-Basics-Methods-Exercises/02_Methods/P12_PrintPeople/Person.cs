namespace P12_PrintPeople
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string occupation;

        public Person(string name, int age, string occupation)
        {
            this.name = name;
            this.age = age;
            this.occupation = occupation;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public int CompareTo(Person other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return string.Format("{0} - age: {1}, occupation: {2}", this.name, this.age, this.occupation);
        }
    }
}