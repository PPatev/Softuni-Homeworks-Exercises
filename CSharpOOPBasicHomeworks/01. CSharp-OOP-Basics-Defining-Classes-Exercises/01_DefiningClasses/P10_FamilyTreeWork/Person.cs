namespace P10_FamilyTreeWork
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string name;
        public string birthday;
        public List<Person> parents;
        public List<Person> children;

        public Person(string name, string birthday)
        {
            this.name = name;
            this.birthday = birthday;
            this.parents = new List<Person>();
            this.children = new List<Person>();
        }

        public Person(string nameOrBirthday)
        {
            if (!nameOrBirthday.Contains("/"))
            {
                this.name = nameOrBirthday;
                this.birthday = null;
            }
            else
            {
                this.name = null;
                this.birthday = nameOrBirthday;
            }

            this.parents = new List<Person>();
            this.children = new List<Person>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("{0} {1}", this.name, this.birthday));
            result.AppendLine("Parents:");
            foreach (Person parent in this.parents)
            {
                result.AppendLine(string.Format("{0} {1}", parent.name, parent.birthday));
            }

            result.AppendLine("Children:");
            foreach (Person child in this.children)
            {
                result.AppendLine(string.Format("{0} {1}", child.name, child.birthday));
            }

            return result.ToString();
        }
    }
}

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    
    public class Person
    {
        public string name;
        public DateTime birthday;
        public List<Person> parents;
        public List<Person> children;

        public Person(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;
            this.parents = new List<Person>();
            this.children = new List<Person>();
        }

        public Person(string name)
            : this(name, default(DateTime))
        {
        }

        public Person(DateTime birthday)
            : this(string.Empty, birthday)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format(
                "{0} {1}",
                this.name,
                this.birthday.ToString("d/M/yyyy", CultureInfo.InvariantCulture)));

            result.AppendLine("Parents:");
            foreach (Person parent in this.parents)
            {
                result.AppendLine(string.Format(
                    "{0} {1}",
                    parent.name,
                    parent.birthday.ToString("d/M/yyyy", CultureInfo.InvariantCulture)));
            }

            result.AppendLine("Children:");
            foreach (Person child in this.children)
            {
                result.AppendLine(string.Format(
                    "{0} {1}",
                    child.name,
                    child.birthday.ToString("d/M/yyyy", CultureInfo.InvariantCulture)));
            }

            return result.ToString();
        }
    }
}
*/

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person : IComparable<Person>
    {
        public Person(string name, string birthday, int number)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public Person(string nameOrBirthday, int number)
        {
            if (nameOrBirthday.Contains(" "))
            {
                this.Name = nameOrBirthday;
                this.Birthday = null;
            }
            else
            {
                this.Name = null;
                this.Birthday = nameOrBirthday;
            }

            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public SortedSet<Person> Parents { get; set; }

        public SortedSet<Person> Children { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("{0} {1}", this.Name, this.Birthday));
            result.AppendLine("Parents:");
            foreach (Person parent in this.Parents)
            {
                result.AppendLine(string.Format("{0} {1}", parent.Name, parent.Birthday));
            }

            result.AppendLine("Children:");
            foreach (Person child in this.Children)
            {
                result.AppendLine(string.Format("{0} {1}", child.Name, child.Birthday));
            }

            return result.ToString();
        }

        public int CompareTo(Person other)
        {
            return this.Number.CompareTo(other.Number);
        }
    }
}
*/

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person : IComparable<Person>
    {
        public Person(string name, string birthday, int number)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public Person(string nameOrBirthday, int number)
        {
            if (nameOrBirthday.Contains(" "))
            {
                this.Name = nameOrBirthday;
                this.Birthday = null;
            }
            else
            {
                this.Name = null;
                this.Birthday = nameOrBirthday;
            }

            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public SortedSet<Person> Parents { get; set; }

        public SortedSet<Person> Children { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("{0} {1}", this.Name, this.Birthday));
            result.AppendLine("Parents:");
            foreach (Person parent in this.Parents)
            {
                result.AppendLine(string.Format("{0} {1}", parent.Name, parent.Birthday));
            }

            result.AppendLine("Children:");
            foreach (Person child in this.Children)
            {
                result.AppendLine(string.Format("{0} {1}", child.Name, child.Birthday));
            }

            return result.ToString();
        }

        public int CompareTo(Person other)
        {
            return this.Number.CompareTo(other.Number);
        }
    }
}
*/
/*
public class Person : IComparable<Person>
    {
        public Person(string name, string birthday, int number)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public Person(string nameOrBirthday, int number)
        {
            if (nameOrBirthday.Contains(" "))
            {
                this.Name = nameOrBirthday;
                this.Birthday = null;
            }
            else
            {
                this.Name = null;
                this.Birthday = nameOrBirthday;
            }

            this.Parents = new SortedSet<Person>();
            this.Children = new SortedSet<Person>();
            this.Number = number;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public SortedSet<Person> Parents { get; set; }

        public SortedSet<Person> Children { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("{0} {1}", this.Name, this.Birthday));
            result.AppendLine("Parents:");
            foreach (Person parent in this.Parents)
            {
                result.AppendLine(string.Format("{0} {1}", parent.Name, parent.Birthday));
            }

            result.AppendLine("Children:");
            foreach (Person child in this.Children)
            {
                result.AppendLine(string.Format("{0} {1}", child.Name, child.Birthday));
            }

            return result.ToString();
        }

        public int CompareTo(Person other)
        {
            return this.Number.CompareTo(other.Number);
        }
    }
}
*/