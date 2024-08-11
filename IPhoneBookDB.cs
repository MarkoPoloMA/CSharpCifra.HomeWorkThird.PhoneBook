using System.Collections.Generic;

namespace CSharpHomeWork.Phonebook
{
	public abstract class IPhoneBookDB
	{
		public abstract void AddNumber(Abonent abonent);
		public abstract void DeleteNumber(Abonent abonent);
		public abstract List<Abonent> GetAllAbonents();
		public abstract void SetList(List<Abonent> abonents);
		public abstract int GetSize();
	}

	internal class PhoneBook : IPhoneBookDB
	{
		private List<Abonent> abonents = new();
		public override void AddNumber(Abonent abonent)
		{
			abonents.Add(abonent);
		}
		public override void DeleteNumber(Abonent abonent)
		{
			abonents.Remove(abonent);
		}
		public override List<Abonent> GetAllAbonents()
		{
			return abonents;
		}
		public override void SetList(List<Abonent> abonents)
		{
			this.abonents = abonents;
		}
		public override int GetSize()
		{
			return abonents.Count;
		}
	}
	
}