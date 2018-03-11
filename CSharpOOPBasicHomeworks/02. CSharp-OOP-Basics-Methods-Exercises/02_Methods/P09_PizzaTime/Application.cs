namespace P09_PizzaTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class Application
    {
        public static void Main()
        {
            MethodInfo[] methods = typeof(Pizza).GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            SortedDictionary<int, List<string>> pizzas = Pizza.GetPizzasByGroups(Console.ReadLine().Split());
            foreach (KeyValuePair<int, List<string>> kvp in pizzas)
            {
                Console.WriteLine("{0} - {1}", kvp.Key, string.Join(", ", kvp.Value));
            }
        }
    }
}