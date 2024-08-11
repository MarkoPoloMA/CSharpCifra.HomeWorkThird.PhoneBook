using System.Linq;

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
			return phoneBookDB.GetAllAbonents().FirstOrDefault(abonent => abonent.GetName() == name);
		}
		public override Abonent FinderOnTelefoneNumberAbonent(long telefone)
		{
			return phoneBookDB.GetAllAbonents().FirstOrDefault(abonent => abonent.GetTelefoneNumber() == telefone);
		}
	}
}
