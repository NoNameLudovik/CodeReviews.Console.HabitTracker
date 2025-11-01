namespace NoNameLudovik.HabitLogger;
internal class Program
{
    static void Main(string[] args)
    {
        SqlHelper.InitiateDataBase();
        Menu.ShowMenu();
    }
}

