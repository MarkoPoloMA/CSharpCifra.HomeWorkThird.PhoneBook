
using System;

namespace CSharpHomeWork.Phonebook
{
	public class Abonent : IEquatable<Abonent>
	{
		private string name;
		private long telefone;

		public Abonent(string name, long telefone)
		{
			this.name = name;
			this.telefone = telefone;
		}
		public bool Equals(Abonent other)
		{
			if (other is null)
				return false;
			if (ReferenceEquals(this, other))
				return true;

			return name == other.name && telefone == other.telefone;
		}
		public override int GetHashCode()
		{
			int someHashCode= 5;
			someHashCode = someHashCode * 11 + (name != null ? name.GetHashCode() : 0);
			someHashCode = someHashCode * 11 + telefone.GetHashCode();
			return someHashCode;
		}
		public string GetName() { return name; }
		public long GetTelefoneNumber() { return telefone; }
		public override string ToString() => $"{name}, {telefone}";
	}
}