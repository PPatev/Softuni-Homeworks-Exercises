namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Application
    {
        private static List<Person> persons = new List<Person>();

        private static string GetInfoPerson(string infoPerson)
        {
            infoPerson = infoPerson.Trim();
            if (infoPerson.Contains(" "))
            {
                string[] names = infoPerson.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                return string.Format("{0} {1}", names[0], names[1]);
            }

            return infoPerson;
        }

        private static string GetInfoPerson(string first, string last)
        {
            first = first.Trim();
            last = last.Trim();

            return string.Format("{0} {1}", first, last);
        }

        private static Person DefinePerson(string infoPerson)
        {
            Person person = null;
            person = persons.FirstOrDefault(p => p.Name.Equals(infoPerson) || p.Date.Equals(infoPerson));
            if (person == null)
            {
                person = new Person(infoPerson);
                persons.Add(person);
            }

            return person;
        }

        private static void SwichPersons(Person first, Person second)
        {
            if (!second.Name.Equals(string.Empty))
            {
                first.Name = second.Name;
            }

            if (!second.Date.Equals(string.Empty))
            {
                first.Date = second.Date;
            }

            foreach (Person parent in second.Parents)
            {
                parent.Children.Remove(second);
                parent.Children.Add(first);
                first.Parents.Add(parent);
            }

            foreach (Person child in second.Children)
            {
                child.Parents.Remove(second);
                child.Parents.Add(first);
                first.Children.Add(child);
            }

            persons.Remove(second);
        }

        public static void Main()
        {
            Person firstPerson = DefinePerson(GetInfoPerson(Console.ReadLine()));

            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] info = line.Split('-');
                if (info.Length == 2)
                {
                    Person parent = DefinePerson(GetInfoPerson(info[0]));
                    Person child = DefinePerson(GetInfoPerson(info[1]));
                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }
                else if (info.Length == 1)
                {
                    string[] infoIdentical = info[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    Person personName = DefinePerson(GetInfoPerson(infoIdentical[0], infoIdentical[1]));
                    Person personDate = DefinePerson(GetInfoPerson(infoIdentical[2]));

                    if (persons.IndexOf(personName) < persons.IndexOf(personDate))
                    {
                        SwichPersons(personName, personDate);
                    }
                    else if (persons.IndexOf(personDate) < persons.IndexOf(personName))
                    {
                        SwichPersons(personDate, personName);
                    }
                }

                line = Console.ReadLine().Trim();
            }

            Console.Write(firstPerson);
        }
    }

    public class Person
    {
        public Person(string name, string date)
        {
            this.Name = name;
            this.Date = date;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public Person(string nameOrDate)
        {
            if (nameOrDate.Contains(" "))
            {
                this.Name = nameOrDate;
                this.Date = string.Empty;
            }
            else
            {
                this.Name = string.Empty;
                this.Date = nameOrDate;
            }

            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public string Name { get; set; }

        public string Date { get; set; }

        public List<Person> Parents { get; set; }

        public List<Person> Children { get; set; }

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
    }
}