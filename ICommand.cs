using System;
using System.Collections.Generic;

namespace CSharpHomeWork.Phonebook
{
	public interface ICommand
	{
		void Execute();
	}

	public class ShowAbonentsCommand : ICommand
	{
		private readonly IPhoneBookDB phoneBookDB;
		public ShowAbonentsCommand(IPhoneBookDB phoneBookDB)
		{
			this.phoneBookDB = phoneBookDB;
		}
		public void Execute()
		{
			List<Abonent> allAbonents = phoneBookDB.GetAllAbonents();

			Console.Clear();
			Console.WriteLine("Список всех абонентов: ");
			for (int i = 0; i < allAbonents.Count; i++)
				Console.WriteLine($"{i + 1} - {allAbonents[i].ToString()}");

			Console.ReadKey();
			Console.WriteLine();
		}
	}

	public class AddAbonentCommand : ICommand
	{
		private readonly IPhoneBookDB phoneBookDB;
		private readonly IAbonentReader abonentReader;

		public AddAbonentCommand(IPhoneBookDB phoneBookDB, IAbonentReader abonentReader)
		{
			this.phoneBookDB = phoneBookDB;
			this.abonentReader = abonentReader;
		}
		public void Execute()
		{
			Abonent abonent = abonentReader.Read();
			phoneBookDB.AddNumber(abonent);
			Console.WriteLine($"Абонент {abonent.GetName()} c телефоном {abonent.GetTelefoneNumber()} добавлен.");
			Console.ReadKey();
			Console.Clear();
		}
	}

	public class DeleteAbonentCommand : ICommand
	{
		private IPhoneBookDB phoneBookDB;
		private IAbonentReader abonentReader;

		public DeleteAbonentCommand(IPhoneBookDB phoneBookDB, IAbonentReader abonentReader)
		{
			this.phoneBookDB = phoneBookDB;
			this.abonentReader = abonentReader;
		}
		public void Execute()
		{
			Abonent abonent = abonentReader.Read();
			phoneBookDB.DeleteNumber(abonent);
			Console.WriteLine($"Абонент {abonent.GetName()} c телефоном {abonent.GetTelefoneNumber()} удален.");
		}
	}

	public class SaveAbonentsCommand : ICommand
	{
		private IPhoneBookDB phoneBookDB = new PhoneBook();
		private IPhoneBookWriter phoneBookWriter = new PhoneBookWriter();
		private string filename;

		public SaveAbonentsCommand(IPhoneBookDB phoneBookDB, IPhoneBookWriter phoneBookWriter, string fileName)
		{
			this.phoneBookDB = phoneBookDB;
			this.phoneBookWriter = phoneBookWriter;
			this.filename = fileName;
		}
		public void Execute()
		{
			List<Abonent> allAbonents = phoneBookDB.GetAllAbonents();
			phoneBookWriter.WriteToFile(allAbonents, filename);
			Console.WriteLine("Успешно сохранено");
		}
	}

	public class LoadAbonentsCommand : ICommand
	{
		private IPhoneBookWriter phoneBookWriter = new PhoneBookWriter();
		private string filename;
		private readonly IPhoneBookDB phoneBookDB;
		public LoadAbonentsCommand(IPhoneBookDB phoneBookDB, IPhoneBookWriter phoneBookWriter, string fileName)
		{
			this.phoneBookDB = phoneBookDB;
			this.phoneBookWriter = phoneBookWriter;
			this.filename = fileName;
		}
		public void Execute()
		{
			var allAbonents = phoneBookWriter.ReadFromFile(filename);

			Console.WriteLine("Список всех абонентов: ");
			for (int i = 0; i < allAbonents.Count; i++)
				Console.WriteLine($"{i + 1} - {allAbonents[i].ToString()}");

			phoneBookDB.SetList(allAbonents);
			Console.ReadKey();
			Console.WriteLine();
		}
	}
}