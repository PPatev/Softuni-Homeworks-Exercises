namespace P04_CompanyRoster
{
    using System;

    public class Employee : IComparable<Employee>
    {
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:F2} {2} {3}", this.name, this.salary, this.email, this.age);
        }

        public int CompareTo(Employee other)
        {
            return other.salary.CompareTo(this.salary);
        }
    }
}

/*
        public Employee(string name, decimal salary, string position, string department)
            : this(name, salary, position, department, "n/a", -1)
        {
        }

        public Employee(string name, decimal salary, string position, string department, string email)
            : this(name, salary, position, department, email, -1)
        {
        }

        public Employee(string name, decimal salary, string position, string department, int age)
            : this(name, salary, position, department, "n/a", age)
        {
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }
*/

/*
namespace P04_CompanyRoster
{
    using System;

    public class Employee : IComparable<Employee>
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = "n/a";
            this.Age = -1;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null, empty or white space.");
                }

                this.name = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }

                this.salary = value;
            }
        }

        public string Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Position cannot be null, empty or white space.");
                }

                this.position = value;
            }
        }

        public string Department
        {
            get
            {
                return this.department;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Department cannot be null, empty or white space.");
                }

                this.department = value;
            }
        }

        public string Email
        {
            get
            {
                if (this.email != null)
                {
                    return this.email;
                }

                return "n/a";
            }

            set
            {
                if (!value.Equals("n/a") && !value.Contains("@"))
                {
                    throw new ArgumentException("Email should contain @");
                }

                this.email = value;
            }
        }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1:F2} {2} {3}", this.Name, this.Salary, this.Email, this.Age);
        }

        public int CompareTo(Employee other)
        {
            return other.Salary.CompareTo(this.Salary);
        }
    }
}
*/