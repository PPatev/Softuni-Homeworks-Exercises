namespace P03_Mankind
{
    using System;
    using System.Linq;
    using System.Text;

    public class Application
    {
        public static void Main()
        {
            Student student = null;
            Worker worker = null;
            try
            {
                string[] infoStudent = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                student = new Student(
                    infoStudent[0],
                    infoStudent[infoStudent.Length - 2],
                    infoStudent[infoStudent.Length - 1]);

                string[] infoWorker = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                worker = new Worker(
                    infoWorker[0],
                    infoWorker[1],
                    decimal.Parse(infoWorker[2]),
                    decimal.Parse(infoWorker[3]));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            if (student != null && worker != null)
            {
                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
        }
    }

    internal class Human
    {
        private string firstName;
        private string lastName;

        internal Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected virtual string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        protected virtual string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("First Name: {0}", this.FirstName));
            result.AppendLine(string.Format("Last Name: {0}", this.LastName));

            return result.ToString();
        }
    }

    internal class Student : Human
    {
        private string facultyNumber;

        internal Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        protected override string FirstName
        {
            get
            {
                return base.FirstName;
            }

            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        protected string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (!this.ValidateFacultyNumber(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine(string.Format("Faculty number: {0}", this.FacultyNumber));

            return result.ToString();
        }

        private bool ValidateFacultyNumber(string fn)
        {
            if (fn.Length < 5 || 10 < fn.Length)
            {
                return false;
            }

            return fn.All(c => char.IsLetterOrDigit(c));
        }
    }

    internal class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        internal Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        
        protected decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        protected decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 1 || 12 < value)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine(string.Format("Week Salary: {0:F2}", this.WeekSalary));
            result.AppendLine(string.Format("Hours per day: {0:F2}", this.WorkHoursPerDay));
            result.AppendLine(string.Format("Salary per hour: {0:F2}", (this.WeekSalary / this.WorkHoursPerDay) / 5));

            return result.ToString();
        }
    }
}