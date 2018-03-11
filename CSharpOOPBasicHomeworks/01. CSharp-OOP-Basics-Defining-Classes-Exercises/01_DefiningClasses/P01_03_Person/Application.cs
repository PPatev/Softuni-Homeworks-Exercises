namespace P01_03_Person
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> persons = new SortedSet<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                persons.Add(new Person(line[0], int.Parse(line[1])));
            }

            foreach (Person person in persons)
            {
                if (person.Age > 30)
                {
                    Console.WriteLine("{0} - {1}", person.Name, person.Age);
                }
            }
        }
    }
}