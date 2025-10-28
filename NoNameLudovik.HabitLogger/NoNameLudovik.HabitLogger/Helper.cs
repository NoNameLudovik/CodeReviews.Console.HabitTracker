/*Helper - contains useful methods and classes*/

using System.Globalization;

namespace NoNameLudovik.HabitLogger
{
    internal class Helper
    {
        internal static DateTime GetDate()
        {
            string? input;
            DateTime date;

            while(true)
            {
                input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
                {
                    return date;
                }

                Console.WriteLine(@"Wrong format! Please type date in 'dd-MM-yyyy' format!");
            }
        }

        internal static int GetNumber()
        {
            int result;

            while (true)
            {
                if(Int32.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }

                Console.WriteLine("Wrong input! Please type an integer value!");
            }
            
        }
    }

    public class DrinkWater
    {
        public int id;
        public DateTime date;
        public int quantity;
    }
}
