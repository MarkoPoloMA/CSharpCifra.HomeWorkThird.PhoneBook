using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpHomeWork.Phonebook
{
	public abstract class IPhoneBookWriter
	{
		public abstract void WriteToFile(List<Abonent> abonents, string filename);
		public abstract List<Abonent> ReadFromFile(string filename);
	}

	internal class PhoneBookWriter : IPhoneBookWriter
	{
		public override void WriteToFile(List<Abonent> abonents, string filename)
		{
			try
			{
				if (File.Exists(filename))
					File.Delete(filename);

				var list = abonents.Select(abonent => abonent.ToString()).ToList();

				File.WriteAllLines(filename, list);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erorr: " + ex.Message);
			}
		}
		public override List<Abonent> ReadFromFile(string filename)
		{
			List<Abonent> abonents = new List<Abonent>();
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