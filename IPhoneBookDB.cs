using System.Collections.Generic;

namespace CSharpHomeWork.Phonebook
{
	public abstract class IPhoneBookDB
	{
		public abstract bool AddList(Abonent abonent);
		public abstract bool Delete(Abonent abonent);
		public abstract HashSet<Abonent> GetAllAbonents();
		public abstract void SetList(HashSet<Abonent> abonents);
		public abstract int GetSize();
	}

	internal class PhoneBook : IPhoneBookDB
	{
		private HashSet<Abonent> abonents = new();
		public override bool AddList(Abonent abonent)
		{
			return abonents.Add(abonent);
		}
		public override bool Delete(Abonent abonent)
		{
			return abonents.Remove(abonent);
		}
		public override HashSet<Abonent> GetAllAbonents()
		{
			return abonents;
		}
        public override void SetList(HashSet<Abonent> abonents)
		{
			this.abonents = abonents;
		}
		public override int GetSize()
		{
			return abonents.Count;
		}
	}
}