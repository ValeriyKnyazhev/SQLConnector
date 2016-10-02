using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLConnector
{
	class SQLConnector
	{

		public string getRandomTableString(SqlCommand command)
		{
			string tableName = "Tbl_Gender";
			string result = "";
			command.CommandText = "SELECT * FROM " + tableName + ";";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					for (int i = 0; i < reader.FieldCount; ++i)
					{
						result += reader[i].ToString() + " ";
					}
					result += "\n";
				}
			}
			return result;
		}

		public string getDoctorsString(SqlCommand command)
		{
			string result = "";
			command.CommandText = "SELECT * FROM Tbl_Doctors;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result += reader[0].ToString() + " | " + reader[1].ToString() + " | " + reader[2].ToString() + "\n";
				}
			}
			return result;
		}

		public SortedSet<Doctor> getDoctors(SqlCommand command)
		{
			SortedSet<Doctor> setDoctors = new SortedSet<Doctor>();
			
			command.CommandText = "SELECT * FROM Tbl_Doctors;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					setDoctors.Add(new Doctor(Int32.Parse(reader[0].ToString()), reader[1].ToString(), Boolean.Parse(reader[2].ToString())));
				}
			}
			return setDoctors;
		}

		public string getPatientsString(SqlCommand command)
		{
			string result = "";
			command.CommandText = "SELECT * FROM Tbl_Patients;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result += reader[0].ToString() + " | " + reader[1].ToString() + " | " + reader[2].ToString() + " | " +
						reader[3].ToString() + " | " + reader[4].ToString() + "\n";
				}
			}
			return result;
		}

		public SortedSet<Patient> getPatients(SqlCommand command)
		{
			SortedSet<Patient> setPatients = new SortedSet<Patient>();

			command.CommandText = "SELECT * FROM Tbl_Patients;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					setPatients.Add(new Patient(Int32.Parse(reader[0].ToString()), reader[1].ToString(), Int32.Parse(reader[2].ToString()),
						reader[3].ToString(), reader[4].ToString()));
				}
			}
			return setPatients;
		}

		public string getMedicalEquipmentsString(SqlCommand command)
		{
			string result = "";
			command.CommandText = "SELECT * FROM Tbl_MedicalEquipments;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result += reader[0].ToString() + " | " + reader[1].ToString() + "\n";
				}
			}
			return result;
		}

		public SortedSet<MedicalEquipment> getMedicalEquipments(SqlCommand command)
		{
			SortedSet<MedicalEquipment> setMedicalEquipments = new SortedSet<MedicalEquipment>();

			command.CommandText = "SELECT * FROM Tbl_MedicalEquipments;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					setMedicalEquipments.Add(new MedicalEquipment(Int32.Parse(reader[0].ToString()), reader[1].ToString()));
				}
			}
			return setMedicalEquipments;
		}
	}
}
