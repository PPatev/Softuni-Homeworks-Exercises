namespace P10_FamilyTreeWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Application
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person(Console.ReadLine()));
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                if (!line.Contains("-"))
                {
                    string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = string.Empty;
                    string birthday = string.Empty;
                    if (!info[0].Contains("/"))
                    {
                        name = info[0] + " " + info[1];
                        birthday = info[2]; 
                    }
                    else
                    {
                        birthday = info[0];
                        name = info[1] + " " + info[2];
                    }

                    Person[] identical = persons.Where(p => p.name == name || p.birthday == birthday).ToArray();
                    if (identical.Length == 0)
                    {
                        Person person = new Person(name, birthday);
                        persons.Add(person);
                    }
                    else if (identical.Length >= 1)
                    {
                        if (identical[0].name == null)
                        {
                            identical[0].name = name;
                        }

                        if (identical[0].birthday == null)
                        {
                            identical[0].birthday = birthday;
                        }

                        if (identical.Length == 2)
                        {
                            identical[0].parents = identical[0].parents.Union(identical[1].parents).ToList();
                            identical[0].children = identical[0].children.Union(identical[1].children).ToList();
                            persons.Remove(identical[1]);
                        }
                    }
                }
                else
                {
                    string[] info = line.Split('-');
                    string[] infoP = info[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string infoParent = infoP[0];
                    if (infoP.Length == 2)
                    {
                        infoParent = infoParent + " " + infoP[1];
                    }

                    Person parent = persons.FirstOrDefault(p => p.name == infoParent || p.birthday == infoParent);
                    if (parent == null)
                    {
                        parent = new Person(infoParent);
                        persons.Add(parent);
                    }

                    string[] infoC = info[1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string infoChild = infoC[0];
                    if (infoC.Length == 2)
                    {
                        infoChild = infoChild + " " + infoC[1];
                    }

                    Person child = persons.FirstOrDefault(p => p.name == infoChild || p.birthday == infoChild);
                    if (child == null)
                    {
                        child = new Person(infoChild);
                        persons.Add(child);
                    }

                    parent.children.Add(child);
                    child.parents.Add(parent);
                }

                line = Console.ReadLine();
            }

            Console.Write(persons[0]);
        }
    }
}

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Application
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            string line = Console.ReadLine();
            Person initialPerson;
            DateTime initialBirthday;
            string format = "d/M/yyyy";
            if (line.Contains("/"))
            {
                initialBirthday = DateTime.ParseExact(line, format, CultureInfo.InvariantCulture);
                initialPerson = new Person(initialBirthday);
            }
            else
            {
                initialPerson = new Person(line);
            }

            persons.Add(initialPerson);
            line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                if (!line.Contains("-"))
                {
                    string[] info = line.Split();
                    string name = info[0] + " " + info[1];
                    DateTime birthday = DateTime.ParseExact(info[2], format, CultureInfo.InvariantCulture);

                    Person person;
                    bool personName = persons.Any(p => p.name == name);
                    bool personBirthday = persons.Any(p => p.birthday == birthday);

                    if (!personName && !personBirthday)
                    {
                        person = new Person(name, birthday);
                        persons.Add(person);
                    }
                    else if (personName && !personBirthday)
                    {
                        person = persons.FirstOrDefault(p => p.name == name);
                        person.birthday = birthday;
                    }
                    else if (!personName && personBirthday)
                    {
                        person = persons.FirstOrDefault(p => p.birthday == birthday);
                        person.name = name;
                    }
                    else
                    {
                        Person[] duplicates = persons.Where(p => p.name == name || p.birthday == birthday).ToArray();
                        if (duplicates[0].name == string.Empty)
                        {
                            duplicates[0].name = duplicates[1].name;
                        }
                        else
                        {
                            duplicates[0].birthday = duplicates[1].birthday;
                        }

                        duplicates[0].parents = duplicates[0].parents.Union(duplicates[1].parents).ToList();
                        duplicates[0].children = duplicates[0].children.Union(duplicates[1].children).ToList();
                        persons.Remove(duplicates[1]);
                    }
                }
                else
                {
                    string[] info = line.Split('-');

                    Person parent;
                    DateTime birthdayParent = default(DateTime);
                    if (info[0].Contains("/"))
                    {
                        birthdayParent = DateTime.ParseExact(info[0].TrimEnd(), format, CultureInfo.InvariantCulture);
                        parent = persons.FirstOrDefault(p => p.birthday == birthdayParent);
                        if (parent == null)
                        {
                            parent = new Person(birthdayParent);
                            persons.Add(parent);
                        }
                    }
                    else
                    {
                        parent = persons.FirstOrDefault(p => p.name == info[0].TrimEnd());
                        if (parent == null)
                        {
                            parent = new Person(info[0].TrimEnd());
                            persons.Add(parent);
                        }
                    }

                    Person child;
                    DateTime birthdayChild = default(DateTime);
                    if (info[1].Contains("/"))
                    {
                        birthdayChild = DateTime.ParseExact(info[1].TrimStart(), format, CultureInfo.InvariantCulture);
                        child = persons.FirstOrDefault(p => p.birthday == birthdayChild);
                        if (child == null)
                        {
                            child = new Person(birthdayChild);
                            persons.Add(child);
                        }
                    }
                    else
                    {
                        child = persons.FirstOrDefault(p => p.name == info[1].TrimStart());
                        if (child == null)
                        {
                            child = new Person(info[1].TrimStart());
                            persons.Add(child);
                        }
                    }

                    parent.children.Add(child);
                    child.parents.Add(parent);
                }

                line = Console.ReadLine();
            }

            Console.Write(initialPerson);
        }
    }
}
*/

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            // System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Dictionary<string, Person> names = new Dictionary<string, Person>();
            Dictionary<DateTime, Person> birthdays = new Dictionary<DateTime, Person>();
            string line = Console.ReadLine();
            Person initialPerson;
            DateTime initialBirthday;
            if (DateTime.TryParse(line, out initialBirthday))
            {
                initialPerson = new Person(initialBirthday);
                birthdays.Add(initialBirthday, initialPerson);
            }
            else
            {
                initialPerson = new Person(line);
                names.Add(line, initialPerson);
            }

            line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                if (!line.Contains("-"))
                {
                    string[] info = line.Split();
                    string name = info[0] + " " + info[1];
                    DateTime birthday = DateTime.Parse(info[2]);

                    if (names.ContainsKey(name))
                    {
                        names[name].birthday = birthday;
                        if (!birthdays.ContainsKey(birthday))
                        {
                            birthdays.Add(birthday, names[name]);
                        }
                    }
                    else if (birthdays.ContainsKey(birthday))
                    {
                        birthdays[birthday].name = name;
                        if (!names.ContainsKey(name))
                        {
                            names.Add(name, birthdays[birthday]);
                        }
                    }
                    else
                    {
                        Person person = new Person(name, birthday);
                        names.Add(name, person);
                        birthdays.Add(birthday, person);
                    }
                }
                else
                {
                    string[] info = line.Split('-');

                    Person parent;
                    string nameParent = string.Empty;
                    DateTime birthdayParent = default(DateTime);
                    bool parentName = false;
                    if (!info[0].Contains("/"))
                    {
                        parentName = true;
                        nameParent = info[0].TrimEnd();
                        if (!names.ContainsKey(nameParent))
                        {
                            parent = new Person(nameParent);
                            names.Add(nameParent, parent);
                        }
                        else
                        {
                            parent = names[nameParent];
                        }

                    }
                    else
                    {
                        birthdayParent = DateTime.Parse(info[0].TrimEnd());
                        if (!birthdays.ContainsKey(birthdayParent))
                        {
                            parent = new Person(birthdayParent);
                            birthdays.Add(birthdayParent, parent);
                        }
                        else
                        {
                            parent = birthdays[birthdayParent];
                        }
                    }

                    Person child;
                    string nameChild = string.Empty;
                    DateTime birthdayChild = default(DateTime);
                    bool childName = false;
                    if (!info[1].Contains("/"))
                    {
                        childName = true;
                        nameChild = info[1].TrimStart();
                        if (!names.ContainsKey(nameChild))
                        {
                            child = new Person(nameChild);
                            names.Add(nameChild, child);
                        }
                        else
                        {
                            child = names[nameChild];
                        }
                    }
                    else
                    {
                        birthdayChild = DateTime.Parse(info[1].TrimStart());
                        if (!birthdays.ContainsKey(birthdayChild))
                        {
                            child = new Person(birthdayChild);
                            birthdays.Add(birthdayChild, child);
                        }
                        else
                        {
                            child = birthdays[birthdayChild];
                        }
                    }

                    if (parentName)
                    {
                        if (childName)
                        {
                            names[nameParent].children.Add(names[nameChild]);
                            names[nameChild].parents.Add(names[nameParent]);
                        }
                        else
                        {
                            names[nameParent].children.Add(birthdays[birthdayChild]);
                            birthdays[birthdayChild].parents.Add(names[nameParent]);
                        }
                    }
                    else
                    {
                        if (childName)
                        {
                            birthdays[birthdayParent].children.Add(names[nameChild]);
                            names[nameChild].parents.Add(birthdays[birthdayParent]);
                        }
                        else
                        {
                            birthdays[birthdayParent].children.Add(birthdays[birthdayChild]);
                            birthdays[birthdayChild].parents.Add(birthdays[birthdayParent]);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            Console.Write(initialPerson);
        }
    }
}
*/

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Application
    {
        public static void Main()
        {
            int count = 0;
            List<Person> persons = new List<Person>();
            persons.Add(new Person(Console.ReadLine().Trim(), count++));
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                if (!line.Contains("-"))
                {
                    string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = string.Empty;
                    string birthday = string.Empty;
                    if (!char.IsDigit(info[0][0]))
                    {
                        name = info[0] + " " + info[1];
                        birthday = info[2];
                    }
                    else
                    {
                        birthday = info[0];
                        name = info[1] + " " + info[2];
                    }

                    Person[] identical = persons.Where(p => p.Name == name || p.Birthday == birthday).ToArray();
                    Array.Sort(identical);
                    if (identical.Length == 0)
                    {
                        persons.Add(new Person(name, birthday, count++));
                    }
                    else if (identical.Length > 0)
                    {
                        if (identical[0].Name == null)
                        {
                            identical[0].Name = name;
                        }

                        if (identical[0].Birthday == null)
                        {
                            identical[0].Birthday = birthday;
                        }

                        if (identical.Length == 2)
                        {
                            identical[0].Parents.UnionWith(identical[1].Parents);
                            identical[0].Children.UnionWith(identical[1].Children);
                            persons.Remove(identical[1]);
                        }
                    }
                }
                else
                {
                    string[] info = line.Split('-');
                    string[] infoP = info[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string infoParent = infoP[0];
                    if (infoP.Length == 2)
                    {
                        infoParent = infoParent + " " + infoP[1];
                    }

                    Person parent = persons.FirstOrDefault(p => p.Name == infoParent || p.Birthday == infoParent);
                    if (parent == null)
                    {
                        parent = new Person(infoParent, count++);
                        persons.Add(parent);
                    }

                    string[] infoC = info[1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string infoChild = infoC[0];
                    if (infoC.Length == 2)
                    {
                        infoChild = infoChild + " " + infoC[1];
                    }

                    Person child = persons.FirstOrDefault(p => p.Name == infoChild || p.Birthday == infoChild);
                    if (child == null)
                    {
                        child = new Person(infoChild, count++);
                        persons.Add(child);
                    }

                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }

                line = Console.ReadLine();
            }

            Console.Write(persons[0]);
        }
    }
}
*/

/*
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Application
    {
        public static void Main()
        {
            int count = 0;
            List<Person> persons = new List<Person>();
            persons.Add(new Person(Console.ReadLine(), count++));
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                if (!line.Contains("-"))
                {
                    string[] info = line.Split();
                    string name = info[0] + " " + info[1];
                    string birthday = info[2];
                    Person[] identical = persons.Where(p => p.Name == name || p.Birthday == birthday).ToArray();
                    Array.Sort(identical);
                    if (identical.Length == 0)
                    {
                        persons.Add(new Person(name, birthday, count++));
                    }
                    else
                    {
                        if (identical[0].Name == null)
                        {
                            identical[0].Name = name;
                        }

                        if (identical[0].Birthday == null)
                        {
                            identical[0].Birthday = birthday;
                        }

                        if (identical.Length == 2)
                        {
                            foreach (Person parent in identical[1].Parents)
                            {
                                parent.Children.Remove(identical[1]);
                                parent.Children.Add(identical[0]);
                                identical[0].Parents.Add(parent);
                            }

                            foreach (Person child in identical[1].Children)
                            {
                                child.Parents.Remove(identical[1]);
                                child.Parents.Add(identical[0]);
                                identical[0].Children.Add(child);
                            }

                            persons.Remove(identical[1]);
                        }
                    }
                }
                else
                {
                    string[] info = line.Split('-');
                    string infoParent = info[0].TrimEnd();
                    Person parent = persons.FirstOrDefault(p => p.Name == infoParent || p.Birthday == infoParent);
                    if (parent == null)
                    {
                        parent = new Person(infoParent, count++);
                        persons.Add(parent);
                    }

                    string infoChild = info[1].TrimStart();
                    Person child = persons.FirstOrDefault(p => p.Name == infoChild || p.Birthday == infoChild);
                    if (child == null)
                    {
                        child = new Person(infoChild, count++);
                        persons.Add(child);
                    }

                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }

                line = Console.ReadLine();
            }

            Console.Write(persons[0]);
        }
    }
}
*/

/*
60/100
namespace P10_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Application
    {
        private static Dictionary<string, Person> names = new Dictionary<string, Person>();
        private static Dictionary<string, Person> dates = new Dictionary<string, Person>();
        private static int count = 0;

        private static string GetFullName(string namesPerson)
        {
            string[] namesSplit = namesPerson.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            return string.Format("{0} {1}", namesSplit[0], namesSplit[1]);
        }

        private static string GetFullName(string first, string last)
        {
            return string.Format("{0} {1}", first, last);
        }

        private static Person DefinePerson(string infoPerson)
        {
            Person person = null;
            if (infoPerson.Contains(" "))
            {
                infoPerson = GetFullName(infoPerson);
                if (names.ContainsKey(infoPerson))
                {
                    person = names[infoPerson];
                }
                else
                {
                    person = new Person(infoPerson, count++);
                    names[infoPerson] = person;
                }
            }
            else
            {
                if (dates.ContainsKey(infoPerson))
                {
                    person = dates[infoPerson];
                }
                else
                {
                    person = new Person(infoPerson, count++);
                    dates[infoPerson] = person;
                }
            }

            return person;
        }

        public static void Main()
        {
            Person firstPerson = null;
            string line = Console.ReadLine().Trim();
            if (line.Contains(" "))
            {
                string name = GetFullName(line);
                firstPerson = new Person(name, count++);
                names[name] = firstPerson;
            }
            else
            {
                firstPerson = new Person(line, count++);
                dates[line] = firstPerson;
            }
            
            line = Console.ReadLine().Trim();
            while (!line.Equals("End"))
            {
                string[] info = line.Split('-');
                if (info.Length == 2)
                {
                    Person parent = DefinePerson(info[0].Trim());
                    Person child = DefinePerson(info[1].Trim());
                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }
                else if (info.Length == 1)
                {
                    string[] infoIdentical = info[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = GetFullName(infoIdentical[0], infoIdentical[1]);
                    string date = info[2];

                    List<Person> identical = new List<Person>();

                    if (names.ContainsKey(name))
                    {
                        identical.Add(names[name]);
                    }

                    if (dates.ContainsKey(date))
                    {
                        identical.Add(dates[date]);
                    }

                    identical.Sort();

                    if (identical.Count == 0)
                    {
                        Person person = new Person(name, date, count++);
                        names[name] = person;
                        dates[date] = person;
                    }
                    else
                    {
                        if (identical[0].Name == null)
                        {
                            identical[0].Name = name;
                        }

                        if (identical[0].Birthday == null)
                        {
                            identical[0].Birthday = date;
                        }

                        if (identical.Count == 2)
                        {
                            foreach (Person parent in identical[1].Parents)
                            {
                                parent.Children.Remove(identical[1]);
                                parent.Children.Add(identical[0]);
                                identical[0].Parents.Add(parent);
                            }

                            foreach (Person child in identical[1].Children)
                            {
                                child.Parents.Remove(identical[1]);
                                child.Parents.Add(identical[0]);
                                identical[0].Children.Add(child);
                            }
                        }
                    }
                }

                line = Console.ReadLine().Trim();
            }

            Console.Write(firstPerson);
        }
    }
}
*/