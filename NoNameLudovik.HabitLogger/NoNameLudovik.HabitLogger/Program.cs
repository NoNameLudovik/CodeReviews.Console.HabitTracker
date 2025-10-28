namespace NoNameLudovik.HabitLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu.ShowMenu();

                string? userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        Menu.AddRecord();
                        break;
                    case "2":
                        Menu.EditRecord();
                        break;
                    case "3":
                        Menu.DeleteRecord();
                        break;
                    case "4":
                        Menu.ShowRecords();
                        Console.Write("Type any key to back to menu");
                        Console.ReadKey();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Wrong input! Try again!");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }
    }
}
