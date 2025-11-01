/*Helper - contains useful methods and classes*/

using System.Globalization;

namespace NoNameLudovik.HabitLogger;
internal class Helper
{
    internal static DateTime GetDate()
    {
        string? input;
        DateTime date = new();

        Console.Write(@"Type in a date in 'dd-MM-yyyy' format or 'b' to back to menu: ");

        while (true)
        {
            input = Console.ReadLine();

            if (input == "b") return date;

            if (DateTime.TryParseExact(input, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
            {
                if (!CheckFutureDate(date)) return date;

                Console.WriteLine(@"Your date is in the future! Please type a real date!");
                continue;
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

    private static bool CheckFutureDate(DateTime date)
    {
        if (date > DateTime.Now) return true;

        return false;
    }
}

