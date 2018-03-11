namespace P11_CatLady
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            Dictionary<string, Cat> cats = new Dictionary<string, Cat>();

            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] info = line.Split();
                switch (info[0])
                {
                    case "Siamese":
                        cats.Add(info[1], new Siamese(info[1], int.Parse(info[2])));
                        break;
                    case "Cymric":
                        cats.Add(info[1], new Cymric(info[1], double.Parse(info[2])));
                        break;
                    case "StreetExtraordinaire":
                        cats.Add(info[1], new StreetExtraordinaire(info[1], int.Parse(info[2])));
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(cats[Console.ReadLine()]);
        }
    }
}