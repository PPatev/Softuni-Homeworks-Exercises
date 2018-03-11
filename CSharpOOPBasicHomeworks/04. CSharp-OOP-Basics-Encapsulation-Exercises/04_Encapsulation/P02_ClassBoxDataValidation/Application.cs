namespace P02_ClassBoxDataValidation
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Application
    {
        public static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine("Surface Area - {0:F2}", box.CalculateSurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:F2}", box.CalculateLateralSurfaceArea());
                Console.WriteLine("Volume - {0:F2}", box.CalculateVolume());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.Length * this.height) + (2 * this.width * this.height);
        }

        public double CalculateLateralSurfaceArea()
        {
            return (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double CalculateVolume()
        {
            return this.length * this.width * this.height;
        }
    }
}