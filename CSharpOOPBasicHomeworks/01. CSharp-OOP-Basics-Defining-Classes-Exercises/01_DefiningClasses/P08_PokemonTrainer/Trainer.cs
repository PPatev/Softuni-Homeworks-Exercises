namespace P08_PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        public string name;
        public int badges;
        public List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.name, this.badges, this.pokemons.Count);
        }
    }
}

/*
    public class Trainer : IComparable<Trainer>
    {
        public string name;
        public int badges;
        public HashSet<Pokemon> pokemons;
        public HashSet<string> elements;

        public Trainer(string name)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = new HashSet<Pokemon>();
            this.elements = new HashSet<string>();
        }

        public int CompareTo(Trainer other)
        {
            return other.badges.CompareTo(this.badges);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.name, this.badges, this.pokemons.Count);
        }
    }
*/