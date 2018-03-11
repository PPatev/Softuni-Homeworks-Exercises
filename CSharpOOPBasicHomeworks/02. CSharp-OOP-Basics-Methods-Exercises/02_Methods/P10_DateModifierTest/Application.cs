namespace P10_DateModifierTest
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            int differenceInDays = DateModifier.CalculateDifferenceInDays(startDate, endDate);

            Console.WriteLine(differenceInDays);
        }
    }

    public static class DateModifier
    {
        public static int CalculateDifferenceInDays(string dateOne, string dateTwo)
        {
            DateTime first = CreateDate(dateOne);
            DateTime second = CreateDate(dateTwo);

            if (first <= second)
            {
                int difference = (int)(second - first).TotalDays;
                return difference;
            }

            else
            {
                int difference = (int)(first - second).TotalDays;
                return difference;
            }
        }

        private static DateTime CreateDate(string dateOne)
        {
            var data = dateOne.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int year = int.Parse(data[0]);
            int month = int.Parse(data[1]);
            int day = int.Parse(data[2]);

            var date = new DateTime(year, month, day);
            return date;
        }
    }
}