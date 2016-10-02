using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	class Protocol : IComparable<Protocol>
	{
		private int id;
		private string date;
		private string time;
		private int doctor;
		private int patient;
		private int equipment;
		private string source;

		public Protocol(int id, string date, string time, int doctor, int patient, int equipment, string source)
		{
			this.id = id;
			this.date = date;
			this.time = time;
			this.doctor = doctor;
			this.patient = patient;
			this.equipment = equipment;
			this.source = source;
		}

		public int getId()
		{
			return id;
		}

		public string getDate()
		{
			return date;
		}

		public string getTime()
		{
			return time;
		}

		public int getDoctorId()
		{
			return doctor;
		}

		public int getPatientId()
		{
			return patient;
		}

		public int getEquipmentId()
		{
			return equipment;
		}

		public string getSource()
		{
			return source;
		}

		public int CompareTo(Protocol other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;

			return id.CompareTo(other.getId());
		}
	}
}
