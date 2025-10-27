using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Int32.TryParse(Console.ReadLine(), out quantity);

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
                Console.WriteLine($"{record.id}----{record.date.ToString("dd-MM-yyyy")}----{record.quantity}");
            }
        }

        internal static void DeleteRecord()
        {
            Console.Clear();
            ShowRecords();
            Console.Write("Enter record's ID to delete it: ");
            int id; 
            Int32.TryParse(Console.ReadLine(), out id);
            SQLHelper.DeleteRow(id);

            Console.Clear();
            ShowRecords();
            Console.WriteLine("Record deleted!");
            Console.ReadKey();
        }

        internal static void EditRecord()
        {
            Console.Clear();

            int id;
            DateTime date;
            int quantity;

            ShowRecords();
            Console.Write("Enter record's ID to edit it: ");
            Int32.TryParse(Console.ReadLine(), out id);

            Console.Write(@"Type a date in 'dd-MM-yyyy' format: ");
            date = Helper.GetDate();

            Console.Write(@"Type quantity: ");
            Int32.TryParse(Console.ReadLine(), out quantity);

            SQLHelper.UpdateRow(id, date, quantity);

            Console.Clear();
            ShowRecords();
            Console.WriteLine($"Record with ID {id} was changed!");
            Console.ReadKey();
        }
    }
}
