using System;

namespace CSharpHomeWork.Phonebook
{
	public interface IAbonentReader
	{
		public Abonent Read();
	}
	internal class ConsoleAbonentReader : IAbonentReader
	{
		public Abonent Read()
		{
			Console.Clear();
			Console.Write("Введите имя: ");
			var name = Console.ReadLine();

			Console.Write("Введите номер телефона: ");
			long telefone;

			while(!long.TryParse(Console.ReadLine(), out telefone))
				Console.WriteLine("Неправильный ввод. Вводите заново");
			Console.WriteLine();

			return new Abonent(name, telefone);
		}
	}
}
