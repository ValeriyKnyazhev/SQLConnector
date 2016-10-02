using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	class MedicalEquipment : IComparable<MedicalEquipment>
	{
		private int id;
		private string name;

		public MedicalEquipment(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public int getId()
		{
			return id;
		}

		public string getName()
		{
			return name;
		}

		public int CompareTo(MedicalEquipment other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;

			return id.CompareTo(other.getId());
		}
	}
}
