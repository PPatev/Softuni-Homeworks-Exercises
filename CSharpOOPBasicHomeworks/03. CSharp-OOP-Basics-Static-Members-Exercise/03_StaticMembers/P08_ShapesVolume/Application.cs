namespace P08_ShapesVolume
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                string[] info = line.Split();
                switch (info[0])
                {
                    case "TrianglePrism":
                        TriangularPrism triangularPrism = 
                            new TriangularPrism(
                            double.Parse(info[1]),
                            double.Parse(info[2]),
                            double.Parse(info[3]));
                        Console.WriteLine("{0:F3}", VolumeCalculator.CalculateVolumeTriangularPrism(triangularPrism));
                        break;
                    case "Cube":
                        Cube cube = new Cube(double.Parse(info[1]));
                        Console.WriteLine("{0:F3}", VolumeCalculator.CalculateVolumeCube(cube));
                        break;
                    case "Cylinder":
                        Cylinder cylinder = new Cylinder(double.Parse(info[1]), double.Parse(info[2]));
                        Console.WriteLine("{0:F3}", VolumeCalculator.CalculateVolumeCylinder(cylinder));
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }

    public static class VolumeCalculator
    {
        public static double CalculateVolumeTriangularPrism(TriangularPrism tp)
        {
            return (tp.BaseSide * tp.Height * tp.Length) / 2;
        }

        public static double CalculateVolumeCube(Cube cube)
        {
            return Math.Pow(cube.SideLength, 3);
        }

        public static double CalculateVolumeCylinder(Cylinder cylinder)
        {
            return Math.PI * Math.Pow(cylinder.Radius, 2) * cylinder.Height;
        }
    }

    public class TriangularPrism
    {
        public TriangularPrism(double baseSide, double height, double length)
        {
            this.BaseSide = baseSide;
            this.Height = height;
            this.Length = length;
        }

        public double BaseSide { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }
    }

    public class Cube
    {
        public Cube(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public double SideLength { get; set; }
    }

    public class Cylinder
    {
        public Cylinder(double radius, double height)
        {
            this.Radius = radius;
            this.Height = height;
        }

        public double Radius { get; set; }

        public double Height { get; set; }
    }
}