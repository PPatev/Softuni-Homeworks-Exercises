namespace P05_AnimalClinic
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] info = line.Split();
                switch (info[2])
                {
                    case "heal":
                        Animal animalToHeal = new Animal(info[0], info[1]);
                        AnimalClinic.Heal(animalToHeal);
                        Console.WriteLine(
                            "Patient {0}: [{1} ({2})] has been healed!",
                            AnimalClinic.PatientId,
                            animalToHeal.Name,
                            animalToHeal.Breed);
                        break;
                    case "rehabilitate":
                        Animal animalToRehabilitate = new Animal(info[0], info[1]);
                        AnimalClinic.Rehabilitate(animalToRehabilitate);
                        Console.WriteLine(
                            "Patient {0}: [{1} ({2})] has been rehabilitated!",
                            AnimalClinic.PatientId,
                            animalToRehabilitate.Name,
                            animalToRehabilitate.Breed);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Total healed animals: {0}", AnimalClinic.HealedAnimalsCount);
            Console.WriteLine("Total rehabilitated animals: {0}", AnimalClinic.RehabilitedAnimalsCount);

            switch (Console.ReadLine())
            {
                case "heal":
                    AnimalClinic.DisplayHealed();
                    break;
                case "rehabilitate":
                    AnimalClinic.DisplayRehabilitated();
                    break;
            }
        }
    }

    public static class AnimalClinic
    {
        private static int patientId;
        private static int healedAnimalsCount;
        private static int rehabilitedAnimalsCount;
        private static List<Animal> healed = new List<Animal>();
        private static List<Animal> rehabilitated = new List<Animal>(); 

        public static int PatientId
        {
            get
            {
                return patientId;
            }
        }

        public static int HealedAnimalsCount 
        {
            get
            {
                return healedAnimalsCount;
            }
        }

        public static int RehabilitedAnimalsCount
        {
            get
            {
                return rehabilitedAnimalsCount;
            }
        }

        public static void Heal(Animal animal)
        {
            patientId++;
            healedAnimalsCount++;
            healed.Add(animal);
        }

        public static void Rehabilitate(Animal animal)
        {
            patientId++;
            rehabilitedAnimalsCount++;
            rehabilitated.Add(animal);
        }

        public static void DisplayHealed()
        {
            Console.WriteLine(string.Join(Environment.NewLine, healed));
        }

        public static void DisplayRehabilitated()
        {
            Console.WriteLine(string.Join(Environment.NewLine, rehabilitated));
        }
    }

    public class Animal
    {
        private readonly string name;
        private readonly string breed;

        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Breed
        {
            get
            {
                return this.breed;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Breed);
        }
    }
}