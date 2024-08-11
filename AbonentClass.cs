
namespace CSharpHomeWork.Phonebook
{
	public class Abonent
	{
		private string _name;
		private long _telefone;

		public Abonent(string name, long telefone)
		{
			this._name = name;
			this._telefone = telefone;
		}
		public string GetName() { return _name; }
		public long GetTelefoneNumber() { return _telefone; }
		public override string ToString()
		{
			return $"{_name},{_telefone}";
		}
	}
}