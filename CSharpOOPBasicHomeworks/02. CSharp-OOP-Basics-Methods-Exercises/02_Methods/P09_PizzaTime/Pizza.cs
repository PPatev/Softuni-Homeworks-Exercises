namespace P09_PizzaTime
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Pizza
    {
        private static readonly SortedDictionary<int, List<string>> GroupsPizzas = new SortedDictionary<int, List<string>>();
        private int group;
        private string name;

        public Pizza(int group, string name)
        {
            this.group = group;
            this.name = name;
            if (!GroupsPizzas.ContainsKey(group))
            {
                GroupsPizzas.Add(group, new List<string>());
            }

            GroupsPizzas[group].Add(name);
        }

        public static SortedDictionary<int, List<string>> GetPizzasByGroups(params string[] pizzas)
        {
            foreach (string pizzaInfo in pizzas)
            {
                Regex regex = new Regex(@"\b(\d+)(.*?)\b");
                Match match = regex.Match(pizzaInfo);
                if (regex.IsMatch(pizzaInfo))
                {
                    Pizza pizza = new Pizza(int.Parse(match.Groups[1].ToString()), match.Groups[2].ToString());
                }
            }

            return GroupsPizzas;
        }
    }
}