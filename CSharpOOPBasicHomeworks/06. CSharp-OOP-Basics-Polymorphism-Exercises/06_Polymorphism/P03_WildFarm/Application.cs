namespace P03_WildFarm
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] infoAnimal = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = null;
                switch (infoAnimal[0])
                {
                    case "Zebra":
                        animal = new Zebra(infoAnimal[0], infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3]);
                        break;
                    case "Mouse":
                        animal = new Mouse(infoAnimal[0], infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3]);
                        break;
                    case "Tiger":
                        animal = new Tiger(infoAnimal[0], infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3]);
                        break;
                    case "Cat":
                        animal = new Cat(infoAnimal[0], infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3], infoAnimal[4]);
                        break;
                }

                line = Console.ReadLine();
                string[] infoFood = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                IFood food = null;
                switch (infoFood[0])
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(infoFood[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(infoFood[1]));
                        break;
                }

                animal.MakeSound();

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine(animal);

                line = Console.ReadLine();
            }
        }
    }

    public class Vegetable : Food
    {
        public Vegetable(int quantity)
            : base(quantity)
        {
        }
    }

    public class Meat : Food
    {
        public Meat(int quantity)
            : base(quantity)
        {
        }
    }

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }

    public class Mouse : Mamal
    {
        public Mouse(string type, string name, double weight, string livingRegion)
            : base(type, name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name.Equals("Meat"))
            {
                throw new ArgumentException(string.Format(Constants.WrongFoodMessage, this.Type));
            }

            base.Eat(food);
        }

        protected override string DefineSound()
        {
            return Constants.Mouse;
        }
    }

    public class Zebra : Mamal
    {
        public Zebra(string type, string name, double weight, string livingRegion)
            : base(type, name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name.Equals("Meat"))
            {
                throw new ArgumentException(string.Format(Constants.WrongFoodMessage, this.Type));
            }

            base.Eat(food);
        }

        protected override string DefineSound()
        {
            return Constants.Zebra;
        }
    }

    public class Tiger : Feline
    {
        public Tiger(string type, string name, double weight, string livingRegion)
            : base(type, name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name.Equals("Vegetable"))
            {
                throw new ArgumentException(string.Format(Constants.WrongFoodMessage, this.Type));
            }

            base.Eat(food);
        }

        protected override string DefineSound()
        {
            return Constants.Tiger;
        }
    }

    public class Cat : Feline, IBreedable
    {
        public Cat(string type, string name, double weight, string livingRegion, string breed)
            : base(type, name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        protected override string DefineSound()
        {
            return Constants.Cat;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}[{1}, {2}, {3}, {4}, {5}]", 
                this.Type, 
                this.Name, 
                this.Breed, 
                this.Weight, 
                this.LivingRegion, 
                this.FoodEaten);
        }
    }

    public abstract class Feline : Mamal
    {
        protected Feline(string type, string name, double weight, string livingRegion)
            : base(type, name, weight, livingRegion)
        {
        }
    }

    public abstract class Mamal : Animal, IRegiionLivable
    {
        protected Mamal(string type, string name, double weight, string livingRegion)
            : base(type, name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return string.Format(
                "{0}[{1}, {2}, {3}, {4}]", 
                this.Type, 
                this.Name, 
                this.Weight, 
                this.LivingRegion, 
                this.FoodEaten);
        }
    }

    public abstract class Animal : IAnimal
    {
        protected Animal(string type, string name, double weight)
        {
            this.Type = type;
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
            this.Sound = this.DefineSound();
        }

        public string Type { get; private set; }

        public string Name { get; private set; }
         
        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected string Sound { get; set; }

        public virtual void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
        }

        public void MakeSound()
        {
            Console.WriteLine(this.Sound);
        }

        protected abstract string DefineSound();
    }

    public interface IAnimal : IEater, ISoundMaker
    {
        string Type { get; }

        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }
    }

    public interface IBreedable
    {
        string Breed { get; }
    }

    public interface IRegiionLivable
    {
        string LivingRegion { get; }
    }

    public interface IEater
    {
        void Eat(IFood food);
    }

    public interface ISoundMaker
    {
        void MakeSound();
    }

    public interface IFood
    {
        int Quantity { get; }
    }

    public static class Constants
    {
        public const string Mouse = "SQUEEEAAAK!";
        public const string Tiger = "ROAAR!!!";
        public const string Cat = "Meowwww";
        public const string Zebra = "Zs";
        public const string WrongFoodMessage = "{0}s are not eating that type of food!";
    }
}