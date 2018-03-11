namespace P02_OldestFamilyMember
{
    using System;

    public class Person : IComparable<Person>
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            return this.age.CompareTo(other.age);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.name, this.age);
        }
    }
}