
namespace CSharpHomeWork.Phonebook
{
	internal class Program
	{
		private static void Main()
		{
			const string fileName = @"C:\Users\DELL\source\repos\C#\CSharpHomeWork.Phonebook\phonebook.txt";

			IPhoneBookDB phoneBookDB = new PhoneBook();
			IPhoneBookWriter phoneBookWriter = new PhoneBookWriter();
			IAbonentReader abonentReader = new ConsoleAbonentReader();
			IPhoneBookFinder abonentFinder = new PhoneBookFinder(phoneBookDB);
            IPhoneBookPrint phoneBookPrint = new ConsoleCarWriter();

			ConsoleMenu menu = new ConsoleMenu();

			menu.AddCommand(new ShowAbonentsCommand(phoneBookDB, phoneBookPrint));
			menu.AddCommand(new DeleteAbonentCommand(phoneBookDB, abonentReader, phoneBookPrint));
			menu.AddCommand(new AddAbonentCommand(phoneBookDB, abonentReader, phoneBookPrint));
			menu.AddCommand(new SaveAbonentsCommand(phoneBookDB, phoneBookWriter, fileName));
			menu.AddCommand(new LoadAbonentsCommand(phoneBookDB, phoneBookWriter, fileName, phoneBookPrint));
			menu.AddCommand(new FinderAbonentCommand(phoneBookDB, abonentFinder));

			menu.Run();
		}
	}

}