using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	public class Doctor : IComparable<Doctor>
	{
		private int id;
		private string name;
		private bool status;

		public Doctor(int id, string name, bool status)
		{
			this.id = id;
			this.name = name;
			this.status = status;
		}

		public int getId()
		{
			return id;
		}

		public string getName()
		{
			return name;
		}

		public bool getStatus()
		{
			return status;
		}

		public int CompareTo(Doctor other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;
			
			return id.CompareTo(other.getId());
		}
	}
}
