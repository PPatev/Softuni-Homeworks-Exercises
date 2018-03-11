namespace P01_Students
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                Student student = new Student(line);
                line = Console.ReadLine();
            }

            Console.WriteLine(Student.count);
        }
    }

    public class Student
    {
        public static int count = 0;
        private string name;

        public Student(string name)
        {
            this.name = name;
            count++;
        }
    }
}