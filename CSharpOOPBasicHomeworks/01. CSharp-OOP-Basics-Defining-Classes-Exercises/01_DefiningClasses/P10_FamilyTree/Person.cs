namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /*
    public class Person : IComparable<Person>
    {
        public Person(string name, string birthday, int number)
        {
            this.Name = name;
            this.Date = birthday;
            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public Person(string nameOrBirthday, int number)
        {
            if (nameOrBirthday.Contains(" "))
            {
                this.Name = nameOrBirthday;
                this.Date = null;
            }
            else
            {
                this.Name = null;
                this.Date = nameOrBirthday;
            }

            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public string Name { get; set; }

        public string Date { get; set; }

        public SortedSet<Person> Parents { get; set; }

        public SortedSet<Person> Children { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("{0} {1}", this.Name, this.Date));
            result.AppendLine("Parents:");
            foreach (Person parent in this.Parents)
            {
                result.AppendLine(string.Format("{0} {1}", parent.Name, parent.Date));
            }

            result.AppendLine("Children:");
            foreach (Person child in this.Children)
            {
                result.AppendLine(string.Format("{0} {1}", child.Name, child.Date));
            }

            return result.ToString();
        }

        public int CompareTo(Person other)
        {
            return this.Number.CompareTo(other.Number);
        }
    }*/
}