namespace P06_FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        private static Dictionary<string, Team> teams;

        public static void Main()
        {
            teams = new Dictionary<string, Team>();
            string[] info = Console.ReadLine().Split(';');
            while (!info[0].Equals("END"))
            {
                try
                {
                    switch (info[0])
                    {
                        case "Team":
                            CreateTeam(info[1]);
                            break;
                        case "Add":
                            AddPlayerToTeam(
                                info[1],
                                info[2],
                                double.Parse(info[3]),
                                double.Parse(info[4]),
                                double.Parse(info[5]),
                                double.Parse(info[6]),
                                double.Parse(info[7]));
                            break;
                        case "Remove":
                            RemovePlayerFromTeam(info[1], info[2]);
                            break;
                        case "Rating":
                            PrintRating(info[1]);
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                info = Console.ReadLine().Split(';');
            }
        }

        private static void CreateTeam(string name)
        {
            teams[name] = new Team(name);
        }

        private static void AddPlayerToTeam(
            string nameTeam,
            string namePlayer,
            double endurance,
            double sprint,
            double dribble,
            double passing,
            double shooting)
        {
            if (!teams.ContainsKey(nameTeam))
            {
                throw new ArgumentException(string.Format("Team {0} does not exist.", nameTeam));
            }

            teams[nameTeam].AddPlayer(new Player(namePlayer, endurance, sprint, dribble, passing, shooting));
        }

        private static void RemovePlayerFromTeam(string nameTeam, string namePlayer)
        {
            if (!teams.ContainsKey(nameTeam))
            {
                throw new ArgumentException(string.Format("Team {0} does not exist.", nameTeam));
            }

            teams[nameTeam].RemovePlayer(namePlayer);
        }

        private static void PrintRating(string nameTeam)
        {
            if (!teams.ContainsKey(nameTeam))
            {
                throw new ArgumentException(string.Format("Team {0} does not exist.", nameTeam));
            }

            Console.WriteLine("{0} - {1:F0}", teams[nameTeam].Name, teams[nameTeam].Rating);
        }
    }

    internal class Team
    {
        private string name;
        private List<Player> players;

        internal Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        internal string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        internal double Rating
        {
            get
            {
                return this.CalculateRating();
            }
        }

        internal void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        internal void RemovePlayer(string playerName)
        {
            if (this.players.All(p => p.Name != playerName))
            {
                throw new ArgumentException(string.Format("Player {0} is not in {1} team.", playerName, this.Name));
            }

            this.players.RemoveAll(p => p.Name == playerName);
        }

        private double CalculateRating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            double totalSkillLevel = this.players.Sum(player => player.SkillLevel);
            return totalSkillLevel / this.players.Count;
        }
    }

    internal class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        internal Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.SkillLevel = (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;
        }

        internal string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        internal double SkillLevel { get; private set; }

        private double Endurance
        {
            set
            {
                if (value < 0 || 100 < value)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        private double Sprint
        {
            set
            {
                if (value < 0 || 100 < value)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        private double Dribble
        {
            set
            {
                if (value < 0 || 100 < value)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        private double Passing
        {
            set
            {
                if (value < 0 || 100 < value)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        private double Shooting
        {
            set
            {
                if (value < 0 || 100 < value)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }
    }
}