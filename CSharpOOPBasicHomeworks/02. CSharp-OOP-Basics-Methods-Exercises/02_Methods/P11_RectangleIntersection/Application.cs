namespace P11_RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            int[] infoInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>(infoInput[0]);

            for (int i = 0; i < infoInput[0]; i++)
            {
                string[] info = Console.ReadLine().Split();
                rectangles[info[0]] = new Rectangle(
                    info[0], 
                    double.Parse(info[1]),
                    double.Parse(info[2]),
                    double.Parse(info[3]),
                    double.Parse(info[4]));
            }

            for (int i = 0; i < infoInput[1]; i++)
            {
                string[] info = Console.ReadLine().Split();
                Console.WriteLine(rectangles[info[0]].IntersectionCheck(rectangles[info[1]]).ToString().ToLower());
            }
        }
    }
}