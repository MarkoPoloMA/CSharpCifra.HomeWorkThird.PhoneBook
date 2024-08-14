using System;
using System.Collections.Generic;

namespace CSharpHomeWork.Phonebook
{
	public interface ICommand
	{
		void Execute();
		string Name { get; }
	}

	public class ShowAbonentsCommand : ICommand
	{
		private readonly IPhoneBookDB phoneBookDB;
		private IPhoneBookPrint phoneBookPrint;
		public ShowAbonentsCommand(
			IPhoneBookDB phoneBookDB,
			IPhoneBookPrint phoneBookPrint)
		{
			this.phoneBookDB = phoneBookDB;
			this.phoneBookPrint = phoneBookPrint;
		}
		public void Execute()
		{
			HashSet<Abonent> allAbonents = phoneBookDB.GetAllAbonents();

			Console.Clear();
			phoneBookPrint.WriteAllToConsole(allAbonents);

			Console.ReadKey();
			Console.WriteLine();
		}
		public string Name => "Показать список абонентов";
	}

	public class AddAbonentCommand : ICommand
	{
		private readonly IPhoneBookDB phoneBookDB;
		private readonly IAbonentReader abonentReader;
		private IPhoneBookPrint phoneBookPrint;
		public AddAbonentCommand(
			IPhoneBookDB phoneBookDB,
			IAbonentReader abonentReader, 
			IPhoneBookPrint phoneBookPrint)
		{
			this.phoneBookDB = phoneBookDB;
			this.abonentReader = abonentReader;
			this.phoneBookPrint = phoneBookPrint;
		}
		public void Execute()
		{
			Abonent abonent = abonentReader.Read();

			phoneBookPrint.WriteToConsole(abonent, phoneBookDB.AddList(abonent) ? "добавлен" : "существует в коллекции");

			Console.ReadKey();
			Console.Clear();
		}
		public string Name => "Добавить абонента";
	}

	public class DeleteAbonentCommand : ICommand
	{
		private IPhoneBookDB phoneBookDB;
		private IAbonentReader abonentReader;
		private IPhoneBookPrint phoneBookPrint;

		public DeleteAbonentCommand(
			IPhoneBookDB phoneBookDB,
			IAbonentReader abonentReader, 
			IPhoneBookPrint phoneBookPrint)
		{
			this.phoneBookDB = phoneBookDB;
			this.abonentReader = abonentReader;
			this.phoneBookPrint = phoneBookPrint;
		}
		public void Execute()
		{
			Abonent abonent = abonentReader.Read();

			phoneBookPrint.WriteToConsole(abonent, phoneBookDB.Delete(abonent) ? "удален" : "такого объекта не существует");
		}
		public string Name => "Удалить абонента по номеру";
	}

	public class SaveAbonentsCommand : ICommand
	{
		private IPhoneBookDB phoneBookDB = new PhoneBook();
		private IPhoneBookWriter phoneBookWriter = new PhoneBookWriter();
		private string filename;

		public SaveAbonentsCommand(
			IPhoneBookDB phoneBookDB,
			IPhoneBookWriter phoneBookWriter,
			string fileName)
		{
			this.phoneBookDB = phoneBookDB;
			this.phoneBookWriter = phoneBookWriter;
			this.filename = fileName;
		}
		public void Execute()
		{
			HashSet<Abonent> allAbonents = phoneBookDB.GetAllAbonents();
			phoneBookWriter.WriteToFile(allAbonents, filename);

			Console.WriteLine("Успешно сохранено");
		}
		public string Name => "Сохранить в файл всех Абонентов";
	}

	public class LoadAbonentsCommand : ICommand
	{
		private IPhoneBookWriter phoneBookWriter;
		private string filename;
		private readonly IPhoneBookDB phoneBookDB;
		private IPhoneBookPrint phoneBookPrint;
		public LoadAbonentsCommand(
			IPhoneBookDB phoneBookDB,
			IPhoneBookWriter phoneBookWriter,
			string fileName,
			IPhoneBookPrint phoneBookPrint)
		{
			this.phoneBookDB = phoneBookDB;
			this.phoneBookWriter = phoneBookWriter;
			this.filename = fileName;
			this.phoneBookPrint = phoneBookPrint;
		}
		public void Execute()
		{
			var allAbonents = phoneBookWriter.ReadFromFile(filename);

			phoneBookPrint.WriteAllToConsole(allAbonents);
			phoneBookDB.SetList(allAbonents);

			Console.ReadKey();
			Console.WriteLine();
		}
		public string Name => "Загрузить список всех абонентов";
	}
	public class FinderAbonentCommand : ICommand
	{
		private IPhoneBookDB phoneBookDB;
		private IPhoneBookFinder phoneBookFinder;

		public FinderAbonentCommand(
			IPhoneBookDB phoneBookDB,
			IPhoneBookFinder phoneBookFinder)
		{
			this.phoneBookFinder = phoneBookFinder;
			this.phoneBookDB = phoneBookDB;
		}
		public void Execute()
		{
			Console.WriteLine("Введите имя для поиска: ");
			string name = Console.ReadLine();

			Abonent abonent = phoneBookFinder.FinderOnNameAbonent(name);

			Console.WriteLine(abonent != null 
				? $"Абонент с именем {abonent.GetName()} имеет телефон {abonent.GetTelefoneNumber()}" : "Такого абонента нет!");
		}
		public string Name => "Поиск Абонента по имени";
	}
}