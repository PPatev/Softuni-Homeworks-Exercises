namespace P10_DateModifier
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateModifier dm = new DateModifier(date1, date2);
            Console.WriteLine(dm.Difference);
        }
    }

    public class DateModifier
    {
        private readonly long difference;
        
        public DateModifier(string d1, string d2)
        {
            this.difference = this.CalculateDifference(d1, d2);
        }

        public long Difference
        {
            get
            {
                return this.difference;
            }
        }

        private long CalculateDifference(string d1, string d2)
        {
            string[] dt1 = d1.Split(new char[] { ' ', '\t', '\r', '\n', '/', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] dt2 = d2.Split(new char[] { ' ', '\t', '\r', '\n', '/', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime date1 = new DateTime(int.Parse(dt1[0]), int.Parse(dt1[1]), int.Parse(dt1[2]));
            DateTime date2 = new DateTime(int.Parse(dt2[0]), int.Parse(dt2[1]), int.Parse(dt2[2]));

            return Math.Abs(date1.Subtract(date2).Days);
        }
    }
}

// TimeSpan ts = date1.Subtract(date2).Duration();
/*
namespace P10_DateModifier
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateModifier dm = new DateModifier(date1, date2);
            Console.WriteLine(dm.Difference);
        }
    }

    public class DateModifier
    {
        private readonly long difference;
        
        public DateModifier(string d1, string d2)
        {
            this.difference = this.CalculateDifference(d1, d2);
        }

        public long Difference
        {
            get
            {
                return this.difference;
            }
        }

        private long CalculateDifference(string d1, string d2)
        {
            DateTime date1 = DateTime.Parse(d1);
            DateTime date2 = DateTime.Parse(d2);
            return Math.Abs(date1.Subtract(date2).Days);
        }
    }
}
*/