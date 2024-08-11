
namespace CSharpHomeWork.Phonebook
{
	public class Abonent
	{
		private string name;
		private long telefone;

		public Abonent(string name, long telefone)
		{
			this.name = name;
			this.telefone = telefone;
		}
		public string GetName() { return name; }
		public long GetTelefoneNumber() { return telefone; }
		public override string ToString()
		{
			return $"{name}, {telefone}";
		}
	}
}