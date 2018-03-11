namespace P02_OldestFamilyMember
{
    using System;
    using System.Reflection;

    public class Application
    {
        public static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                family.AddMember(new Person(info[0], int.Parse(info[1])));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}