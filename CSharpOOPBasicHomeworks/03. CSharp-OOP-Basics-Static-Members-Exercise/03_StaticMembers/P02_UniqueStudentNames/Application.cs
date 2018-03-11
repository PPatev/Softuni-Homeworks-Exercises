namespace P02_UniqueStudentNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            Console.WriteLine(StudentGroup.Count);
        }
    }

    public static class StudentGroup
    {
        private static HashSet<Student> students = new HashSet<Student>();

        public static int Count
        {
            get
            {
                return students.Count;
            }
        }

        public static void AddStudent(Student student)
        {
            if (students.All(s => s.Name != student.Name))
            {
                students.Add(student);
            }
        }
    }

    public class Student
    {
        private readonly string name;

        public Student(string name)
        {
            this.name = name;
            StudentGroup.AddStudent(this);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}