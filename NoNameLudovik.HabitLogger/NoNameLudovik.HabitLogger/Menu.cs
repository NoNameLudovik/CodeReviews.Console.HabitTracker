/*Menu class - contains methods for menu working*/

namespace NoNameLudovik.HabitLogger
{
    internal class Menu
    {
        internal static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("-----MENU----");
            Console.WriteLine(
                """
                1. Add Record
                2. Edit Record
                3. Delete Record
                4. All Records
                5. Exit
                """);
            Console.Write("Choose an option: ");
        }

        internal static void AddRecord()
        {
            DateTime date;
            int quantity;

            Console.Clear();
            Console.Write(@"Type a date in 'dd-MM-yyyy' format: ");
            date = Helper.GetDate();

            Console.Clear();
            Console.Write(@"Type quantity: ");
            quantity = Helper.GetNumber();

            SQLHelper.InsertRow(date, quantity);

            Console.WriteLine("Record added!");
            Console.ReadKey();
        }

        internal static void ShowRecords()
        {
            Console.Clear();
            var records = SQLHelper.GetTableRows();

            foreach (var record in records)
            {
                Console.WriteLine($"ID:{record.id}  Date:{record.date.ToString("dd-MM-yyyy")}  Quantity:{record.quantity}");
            }
        }

        internal static void DeleteRecord()
        {
            while (true)
            {
                Console.Clear();
                ShowRecords();
                Console.Write("Enter record's ID to delete it: ");
                int id;
                id = Helper.GetNumber();
                try
                {
                    SQLHelper.IdCheck(id);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }
                SQLHelper.DeleteRow(id);
                Console.Clear();
                ShowRecords();
                Console.WriteLine("Record deleted!");
                Console.ReadKey();
                break;
            }
        }

        internal static void EditRecord()
        {
            

            int id;
            DateTime date;
            int quantity;

            while (true)
            {
                Console.Clear();
                ShowRecords();
                Console.Write("Enter record's ID to edit it: ");
                id = Helper.GetNumber();

                try
                {
                    SQLHelper.IdCheck(id);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }

                Console.Write(@"Type a date in 'dd-MM-yyyy' format: ");
                date = Helper.GetDate();

                Console.Write(@"Type quantity: ");
                quantity = Helper.GetNumber();

                SQLHelper.UpdateRow(id, date, quantity);

                Console.Clear();
                ShowRecords();
                Console.WriteLine($"Record with ID {id} was changed!");
                Console.ReadKey();
                break;
            }
        }
    }
}
