using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	class ExaminationType : IComparable<ExaminationType>
	{
		private int id;
		private string name;

		public ExaminationType(int id, string name)
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

		public int CompareTo(ExaminationType other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;

			return id.CompareTo(other.getId());
		}
	}
}
