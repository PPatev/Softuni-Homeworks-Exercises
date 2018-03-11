namespace P04_MordorsCrueltyPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            IWizard wizard = new Wizard(Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine(wizard.TotalPoints);
            Console.WriteLine(wizard.MoodType);
        }
    }

    internal class Wizard : IWizard
    {
        private readonly int totalPoints;
        private readonly IMood mood;
        private List<IFood> foods;

        internal Wizard(params string[] foodsStrings)
        {
            this.foods = this.Eat(foodsStrings);
            this.totalPoints = this.foods.Sum(food => food.Points);
            this.mood = this.DefineMood();
        }

        public int TotalPoints
        {
            get
            {
                return this.totalPoints;
            }
        }

        public MoodType MoodType
        {
            get
            {
                return this.mood.Type;
            }
        }

        private List<IFood> Eat(params string[] foodsStrings)
        {
            List<IFood> foodEaten = new List<IFood>();
            IFoodFactory foodFacory = new FoodFactory();
            foreach (string foodString in foodsStrings)
            {
                foodEaten.Add(foodFacory.ProduceFood(foodString.ToLower()));
            }

            return foodEaten;
        }

        private IMood DefineMood()
        {
            IMoodFactory moodFactory = new MoodFactory();
            return moodFactory.ProduceMood(this.totalPoints);
        }
    }

    internal class Food : IFood
    {
        private readonly int points;

        internal Food()
        {
            this.points = this.SetPoints();
        }

        public int Points
        {
            get
            {
                return this.points;
            }
        }

        protected virtual int SetPoints()
        {
            return -1;
        }
    }

    internal class Cram : Food
    {
        protected override int SetPoints()
        {
            return 2;
        }
    }

    internal class Lembas : Food
    {
        protected override int SetPoints()
        {
            return 3;
        }
    }

    internal class Apple : Food
    {
        protected override int SetPoints()
        {
            return 1;
        }
    }

    internal class Melon : Food
    {
        protected override int SetPoints()
        {
            return 1;
        }
    }

    internal class HoneyCake : Food
    {
        protected override int SetPoints()
        {
            return 5;
        }
    }

    internal class Mushrooms : Food
    {
        protected override int SetPoints()
        {
            return -10;
        }
    }

    internal class FoodFactory : IFoodFactory
    {
        public IFood ProduceFood(string type)
        {
            switch (type)
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Food();
            }
        }
    }

    internal abstract class Mood : IMood
    {
        protected MoodType type;

        public MoodType Type
        {
            get
            {
                return this.type;
            }
        }
    }

    internal class Angry : Mood
    {
        internal Angry()
        {
            this.type = MoodType.Angry;
        }
    }

    internal class Sad : Mood
    {
        internal Sad()
        {
            this.type = MoodType.Sad;
        }
    }

    internal class Happy : Mood
    {
        internal Happy()
        {
            this.type = MoodType.Happy;
        }
    }

    internal class JavaScript : Mood
    {
        internal JavaScript()
        {
            this.type = MoodType.JavaScript;
        }
    }

    public enum MoodType
    {
        Angry,
        Sad,
        Happy,
        JavaScript
    }

    internal class MoodFactory : IMoodFactory
    {
        public IMood ProduceMood(int totalPoints)
        {
            if (totalPoints < -5)
            {
                return new Angry();
            }
            else if (-5 <= totalPoints && totalPoints < 0)
            {
                return new Sad();
            }
            else if (0 <= totalPoints && totalPoints <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }

    public interface IWizard
    {
        int TotalPoints { get; }

        MoodType MoodType { get; }
    }

    public interface IFood
    {
        int Points { get; }
    }

    public interface IMood
    {
        MoodType Type { get; }
    }

    public interface IFoodFactory
    {
        IFood ProduceFood(string type);
    }

    public interface IMoodFactory
    {
        IMood ProduceMood(int totalPoints);
    }
}