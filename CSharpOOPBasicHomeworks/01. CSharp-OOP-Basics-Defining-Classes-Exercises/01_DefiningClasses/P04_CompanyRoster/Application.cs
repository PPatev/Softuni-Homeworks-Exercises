namespace P04_CompanyRoster
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, SortedSet<Employee>> departmnts = new Dictionary<string, SortedSet<Employee>>();
            Dictionary<string, decimal> salaries = new Dictionary<string, decimal>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                string name = line[0];
                decimal salary = decimal.Parse(line[1]);
                string position = line[2];
                string departnemt = line[3];
                Employee employee = new Employee(name, salary, position, departnemt);

                if (line.Length == 5)
                {
                    if (line[4].Contains("@"))
                    {
                        employee.email = line[4];
                    }
                    else
                    {
                        employee.age = int.Parse(line[4]);
                    }
                }

                if (line.Length == 6)
                {
                    employee.email = line[4];
                    employee.age = int.Parse(line[5]);
                }

                if (!departmnts.ContainsKey(departnemt))
                {
                    departmnts[departnemt] = new SortedSet<Employee>();
                    salaries[departnemt] = 0;
                }

                departmnts[departnemt].Add(employee);
                salaries[departnemt] += salary;
            }

            string maxD = string.Empty;
            decimal max = decimal.MinValue;
            foreach (string department in departmnts.Keys)
            {
                if (departmnts[department].Count != 0)
                {
                    salaries[department] /= departmnts[department].Count;
                }

                if (salaries[department] > max)
                {
                    max = salaries[department];
                    maxD = department;
                }
            }

            Console.WriteLine("Highest Average Salary: {0}", maxD);
            foreach (Employee employee in departmnts[maxD])
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}