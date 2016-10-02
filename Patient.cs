using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	class Patient : IComparable<Patient>
	{
		private int id;
		private string name;
		private int gender;
		private string date;
		private string numberAmbulatoryCard;

		public Patient(int id, string name, int gender, string date, string numberAmbulatoryCard)
		{
			this.id = id;
			this.name = name;
			this.gender = gender;
			this.date = date;
			this.numberAmbulatoryCard = numberAmbulatoryCard;
		}

		public int getId()
		{
			return id;
		}

		public string getName()
		{
			return name;
		}

		public int getGender()
		{
			return gender;
		}

		public string getDate()
		{
			return date;
		}

		public string getNumberAmbulatoryCard()
		{
			return numberAmbulatoryCard;
		}

		public int CompareTo(Patient other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;

			return id.CompareTo(other.getId());
		}
	}
}
