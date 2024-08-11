
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

			ConsoleMenu menu = new ConsoleMenu();

			menu.AddCommand(new ShowAbonentsCommand(phoneBookDB));
			menu.AddCommand(new DeleteAbonentCommand(phoneBookDB, abonentReader));
			menu.AddCommand(new AddAbonentCommand(phoneBookDB, abonentReader));
			menu.AddCommand(new SaveAbonentsCommand(phoneBookDB, phoneBookWriter, fileName));
			menu.AddCommand(new LoadAbonentsCommand(phoneBookDB, phoneBookWriter, fileName));
			menu.AddCommand(new FinderAbonentCommand(phoneBookDB, abonentFinder));
			menu.Run();
		}
	}
}