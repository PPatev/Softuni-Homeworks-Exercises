namespace P08_PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string line = Console.ReadLine();
            while (!line.Equals("Tournament"))
            {
                string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer = trainers.FirstOrDefault(t => t.name == info[0]);
                if (trainer == null)
                {
                    trainer = new Trainer(info[0]);
                    trainers.Add(trainer);
                }
                 
                Pokemon pokemon = new Pokemon(info[1], info[2], int.Parse(info[3]));
                trainer.pokemons.Add(pokemon);
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.pokemons.Any(p => p.element.Equals(line)))
                    {
                        trainer.badges++;
                    }
                    else
                    {
                        trainer.pokemons = trainer.pokemons.Where(p => p.health - 10 > 0).ToList();
                        trainer.pokemons.ForEach(p => p.health -= 10);
                    }
                }

                line = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(t => t.badges).ToList();
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine(trainer);
            }
        }
    }
}

/*
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string line = Console.ReadLine();
            while (!line.Equals("Tournament"))
            {
                string[] info = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer = trainers.FirstOrDefault(t => t.name == info[0]);
                if (trainer == null)
                {
                    trainer = new Trainer(info[0]);
                    trainers.Add(trainer);
                }
                 
                Pokemon pokemon = new Pokemon(info[1], info[2], int.Parse(info[3]));
                trainer.pokemons.Add(pokemon);
                trainer.elements.Add(info[2]);
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.elements.Contains(line))
                    {
                        trainer.badges++;
                    }
                    else
                    {
                        HashSet<Pokemon> pokemonsToRemove = new HashSet<Pokemon>();
                        foreach (Pokemon pokemon in trainer.pokemons)
                        {
                            if (pokemon.health - 10 <= 0)
                            {
                                pokemonsToRemove.Add(pokemon);
                            }
                            else
                            {
                                pokemon.health -= 10;
                            }
                        }

                        foreach (Pokemon pokemon in pokemonsToRemove)
                        {
                            trainer.pokemons.Remove(pokemon);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            trainers.Sort();
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine(trainer);
            }
        }
    }
*/