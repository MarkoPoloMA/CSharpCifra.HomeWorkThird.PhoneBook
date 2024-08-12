using System;
using System.Collections.Generic;

namespace CSharpHomeWork.Phonebook
{
	public abstract class IPhoneBookPrint
    {
        public abstract void WriteToConsole(Abonent abonent, string msg);
        public abstract void WriteAllToConsole(HashSet<Abonent> abonents);
    }

    internal class ConsoleCarWriter : IPhoneBookPrint
    {
        public override void WriteToConsole(Abonent abonent, string msg)
        {
            Console.WriteLine($"Имя: {abonent.GetName()} Телефон: {abonent.GetTelefoneNumber()} {msg}");
        }
        public override void WriteAllToConsole(HashSet<Abonent> abonents)
        {
			Console.WriteLine("Список всех абонентов: ");
			int i = 1;
			foreach (Abonent abonent in abonents)
			{
				Console.WriteLine($"{i} - {abonent.ToString()}");
				i++;
			}
        }
    }
}
