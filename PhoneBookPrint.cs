//using System;
//using System.Collections.Generic;

//namespace CSharpHomeWork.Phonebook
//{
//    abstract class IPhoneBookPrint
//	{
//		public abstract void WriteToConsole(Abonent abonent);
//		public abstract void WriteAllToConsole(List<Abonent> abonents);
//	}

//	internal class ConsoleCarWriter : IPhoneBookPrint
//	{
//		public override void WriteToConsole(Abonent abonent)
//		{
//			Console.WriteLine($"Имя: {abonent.GetName()} Телефон: {abonent.GetTelefoneNumber()}");
//		}
//		public override void WriteAllToConsole(List<Abonent> abonents)
//		{
//			foreach (var abonent in abonents)
//				WriteToConsole(abonent);
//		}
//    }
//}
