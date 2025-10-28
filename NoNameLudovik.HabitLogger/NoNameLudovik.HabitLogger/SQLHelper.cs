/*SQLHelper class - contains methods for working with database*/

using Microsoft.Data.Sqlite;
using System.Globalization;

namespace NoNameLudovik.HabitLogger
{
    internal class SQLHelper
    {
        static string connectionString = @"Data Source=habit-Tracker.db";

        internal static void InitiateDataBase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = "CREATE TABLE IF NOT EXISTS drinking_water(id INTEGER PRIMARY KEY AUTOINCREMENT, date TEXT, quantity INTEGER);";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        internal static void InsertRow(DateTime date, int quantity)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES ('{date.ToString("dd-MM-yyyy")}', {quantity});";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        internal static List<DrinkWater> GetTableRows()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"SELECT * FROM drinking_water;";

                var rows = new List<DrinkWater>();

                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var quantity = reader.GetInt32(2);

                        rows.Add(new DrinkWater
                        {
                            id = reader.GetInt32(0),
                            date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yyyy", new CultureInfo("en-US")),
                            quantity = reader.GetInt32(2)
                        });
                    }
                }
                connection.Close();

                return rows;
            }
        }

        internal static void UpdateRow(int id, DateTime newDate, int newQuantity)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"UPDATE drinking_water SET date = '{newDate.ToString("dd-MM-yyyy")}', quantity = {newQuantity} WHERE id = {id};";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        internal static void DeleteRow(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"DELETE FROM drinking_water WHERE id = {id}";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        internal static void IdCheck(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"SELECT * FROM drinking_water WHERE id = {id}";

                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new Exception($@"Record with ID:{id} doesn't exist");
                }
                connection.Close();
            }
        }
    }
}
