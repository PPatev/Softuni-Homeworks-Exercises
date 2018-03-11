namespace P01_ClassBox
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
            Box box = new Box(length, width, height);

            Console.WriteLine("Surface Area - {0:F2}", box.CalculateSurfaceArea());
            Console.WriteLine("Lateral Surface Area - {0:F2}", box.CalculateLateralSurfaceArea());
            Console.WriteLine("Volume - {0:F2}", box.CalculateVolume());
        }
    }

    public class Box
    {
        private readonly double length;
        private readonly double width;
        private readonly double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double CalculateSurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);            
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