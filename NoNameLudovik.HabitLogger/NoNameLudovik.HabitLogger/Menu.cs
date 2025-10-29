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
            date = Helper.GetDate();

            if(date.Year == 1) return;

            Console.Clear();
            Console.Write(@"Type quantity: ");
            quantity = Helper.GetNumber();

            SqlHelper.InsertRow(date, quantity);

            Console.WriteLine("Record added!");
            Console.ReadKey();
        }

        internal static void ShowRecords()
        {
            Console.Clear();
            var records = SqlHelper.GetTableRows();

            foreach (var record in records)
            {
                Console.WriteLine($"ID:{record.id}  Date:{record.date.ToString("dd-MM-yyyy")}  Quantity:{record.quantity}");
            }
        }

        internal static void DeleteRecord()
        {
            while (true)
            {
                
                try
                {
                    Console.Clear();
                    ShowRecords();
                    Console.Write(@"Type in record's ID to delete it or 'b' to back to menu: ");
                    int id;
                    id = Helper.GetNumber();

                    if (id == 0) break;

                    SqlHelper.IdCheck(id);

                    SqlHelper.DeleteRow(id);
                    Console.Clear();
                    ShowRecords();
                    Console.WriteLine("Record deleted!");
                    Console.ReadKey();
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }
            }
        }

        internal static void EditRecord()
        {
            int id;
            DateTime date;
            int quantity;

            while (true)
            {
                try
                {
                    Console.Clear();
                    ShowRecords();
                    Console.Write(@"Type in record's ID to edit it or 'b' to back to menu: ");
                    id = Helper.GetNumber();

                    if (id == 0) break;

                    SqlHelper.IdCheck(id);
                    date = Helper.GetDate();

                    Console.Write(@"Type quantity: ");
                    quantity = Helper.GetNumber();

                    SqlHelper.UpdateRow(id, date, quantity);

                    Console.Clear();
                    ShowRecords();
                    Console.WriteLine($"Record with ID {id} was changed!");
                    Console.ReadKey();
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }
            }
        }
    }
}
