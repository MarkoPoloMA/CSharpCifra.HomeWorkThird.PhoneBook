using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpHomeWork.Phonebook
{
	public abstract class IPhoneBookWriter
	{
		public abstract void WriteToFile(HashSet<Abonent> abonents, string fileName);
		public abstract HashSet<Abonent> ReadFromFile(string filename);
	}

	internal class PhoneBookWriter : IPhoneBookWriter
	{
		public override void WriteToFile(HashSet<Abonent> abonents, string fileName)
		{
			try
			{
				if (File.Exists(fileName))
					File.Delete(fileName);

				var list = abonents.Select(abonent => abonent.ToString()).ToList();

				File.WriteAllLines(fileName, list);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erorr: " + ex.Message);
			}
		}
		public override HashSet<Abonent> ReadFromFile(string filename)
		{
			HashSet<Abonent> abonents = new HashSet<Abonent>();
			try
			{
				var readAllLines = File.ReadAllLines(filename);

				foreach (string line in readAllLines)
				{
					var data = line.Split(',');

					var abonent = new Abonent(data[0], long.Parse(data[1]));
					abonents.Add(abonent);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}

			return abonents;
		}
	}
}