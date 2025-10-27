using System.Globalization;

namespace NoNameLudovik.HabitLogger
{
    internal class Helper
    {
        internal static DateTime GetDate()
        {
            string date = Console.ReadLine();

            return DateTime.ParseExact(date, "dd-MM-yyyy", new CultureInfo("en-US"));
        }

         
    }

    public class DrinkWater
    {
        public int id;
        public DateTime date;
        public int quantity;
    }
}
