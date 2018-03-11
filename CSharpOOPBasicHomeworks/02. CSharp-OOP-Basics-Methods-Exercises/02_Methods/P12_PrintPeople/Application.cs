namespace P12_PrintPeople
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();

            string line = Console.ReadLine();
            while (!line.Equals("END"))
            {
                string[] info = line.Split();
                persons.Add(new Person(info[0], int.Parse(info[1]), info[2]));

                line = Console.ReadLine();
            }

            persons.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, persons));
        }
    }
}