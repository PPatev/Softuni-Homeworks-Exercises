namespace P06_Animals
{
    using System;
    using System.Text;
    using System.Threading;

    public class Application
    {
        public static void Main()
        {
            const string ExceptionMessage = "Invalid input!";
            string line = Console.ReadLine();
            while (!line.Equals("Beast!"))
            {
                try
                {
                    string[] info = Console.ReadLine()
                        .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (info.Length != 3)
                    {
                        throw new ArgumentException(ExceptionMessage);
                    }

                    IAnimal animal = null;
                    switch (line.ToLower())
                    {
                        case "dog":
                            animal = new Dog(info[0], info[1], info[2]);
                            Console.Write(animal);
                            break;
                        case "frog":
                            animal = new Frog(info[0], info[1], info[2]);
                            Console.Write(animal);
                            break;
                        case "cat":
                            animal = new Cat(info[0], info[1], info[2]);
                            Console.Write(animal);
                            break;
                        case "kitten":
                            animal = new Kitten(info[0], info[1], info[2]);
                            Console.Write(animal);
                            break;
                        case "tomcat":
                            animal = new Tomcat(info[0], info[1], info[2]);
                            Console.Write(animal);
                            break;
                        default:
                            throw new ArgumentException(ExceptionMessage);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                
                line = Console.ReadLine();
            }
        }
    }

    internal class Tomcat : Cat
    {
        private const string ExceptionMessage = "Invalid input!";

        internal Tomcat(string name, string animalAge, string gender)
            : base(name, animalAge, gender)
        {
        }

        public override string Gender
        {
            get
            {
                return base.Gender;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                base.Gender = "Male";
            }
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }

    internal class Kitten : Cat
    {
        private const string ExceptionMessage = "Invalid input!";

        internal Kitten(string name, string animalAge, string gender)
            : base(name, animalAge, gender)
        {
        }

        public override string Gender
        {
            get
            {
                return base.Gender;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                base.Gender = "Female";
            }
        }

        public override string ProduceSound()
        {
            return "Miau";
        }
    }

    internal class Cat : Animal
    {
        internal Cat(string name, string animalAge, string gender)
            : base(name, animalAge, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MiauMiau";
        }
    }

    internal class Dog : Animal
    {
        internal Dog(string name, string animalAge, string gender)
            : base(name, animalAge, gender)
        {
        }

        public override string ProduceSound()
        {
            return "BauBau";
        }
    }

    internal class Frog : Animal
    {
        internal Frog(string name, string animalAge, string gender)
            : base(name, animalAge, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Frogggg";
        }
    }

    internal abstract class Animal : IAnimal
    {
        private const string ExceptionMessage = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        internal Animal(string name, string animalAge, string gender)
        {
            this.Name = name;
            this.age = this.ParseAge(animalAge);
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public virtual string Gender
        {
            get
            {
                return this.gender;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.ToLower() != "male" && value.ToLower() != "female"))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.GetType().Name);
            result.AppendLine(string.Format("{0} {1} {2}", this.Name, this.Age, this.Gender));
            result.AppendLine(this.ProduceSound());

            return result.ToString();
        }

        private int ParseAge(string animalAge)
        {
            int ageAnimal;
            try
                {
                    if (string.IsNullOrWhiteSpace(animalAge))
                    {
                        throw new ArgumentException(ExceptionMessage);
                    }

                    ageAnimal = int.Parse(animalAge);
                    if (ageAnimal < 0)
                    {
                        throw new ArgumentException(ExceptionMessage);
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException(ExceptionMessage);
                }

            return ageAnimal;
        }
    }

    internal interface IAnimal : ISoundProducible
    {
        string Name { get; }

        int Age { get; }

        string Gender { get; }
    }

    internal interface ISoundProducible
    {
        string ProduceSound();
    }
}