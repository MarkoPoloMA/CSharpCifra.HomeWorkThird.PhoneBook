using System;
using System.Collections.Generic;

namespace CSharpHomeWork.Phonebook
{
	public class ConsoleMenu
	{
		private List<ICommand> _commands = new List<ICommand>();

		public void AddCommand(ICommand command)
		{
			_commands.Add(command);
		}
		public void Run()
		{
			while (true)
			{
				Console.WriteLine("Выберите команду: ");
				for (int i = 0; i < _commands.Count; i++)
				{
					Console.WriteLine($"{i + 1}. { _commands[i].GetType().Name}");
				}
				Console.WriteLine("0. Выход");

				if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _commands.Count)
					_commands[choice - 1].Execute();
				else
					Console.WriteLine("Некорректный выбор, попробуйте снова.");
			}
		}
	}
}
