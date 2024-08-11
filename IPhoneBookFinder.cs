namespace CSharpHomeWork.Phonebook
{
	public abstract class IPhoneBookFinder
	{
		public abstract Abonent FinderOnNameAbonent(string name);
		public abstract Abonent FinderOnTelefoneNumberAbonent(long telefone);
	}

	internal class PhoneBookFinder : IPhoneBookFinder
	{
		private IPhoneBookDB phoneBookDB;
		public PhoneBookFinder(IPhoneBookDB phoneBookDb)
		{
			this.phoneBookDB = phoneBookDb;
		}
		public override Abonent FinderOnNameAbonent(string name)
		{
			foreach (var abonent in phoneBookDB.GetAllAbonents())
			{
				if (abonent.GetName() == name)
					return abonent;
			}

			return null;
		}
		public override Abonent FinderOnTelefoneNumberAbonent(long telefone)
		{
			foreach (var abonent in phoneBookDB.GetAllAbonents())
			{
				if (abonent.GetTelefoneNumber() == telefone)
					return abonent;
			}

			return null;
		}
	}
}
