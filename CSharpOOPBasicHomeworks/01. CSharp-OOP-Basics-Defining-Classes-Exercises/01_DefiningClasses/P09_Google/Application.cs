namespace P09_Google
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];

                if (!persons.ContainsKey(name))
                {
                    persons[name] = new Person(name);
                }

                Person person = persons[name];
                switch (info[1])
                {
                    case "company":
                        person.company = new Person.Company(info[2], info[3], decimal.Parse(info[4]));
                        break;
                    case "car":
                        person.car = new Person.Car(info[2], int.Parse(info[3]));
                        break;
                    case "pokemon":
                        person.pokemons.Add(new Person.Pokemon(info[2], info[3]));
                        break;
                    case "parents":
                        person.parents.Add(new Person.Parent(info[2], info[3]));
                        break;
                    case "children":
                        person.children.Add(new Person.Child(info[2], info[3]));
                        break;
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            Console.Write(persons[line]);
        }
    }
}