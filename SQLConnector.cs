﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLConnector
{
	class SQLConnector
	{

		public string getRandomTableString(SqlCommand command, string tableName, string param)
		{
			string result = "";
			command.CommandText = "SELECT * FROM " + tableName + "\nWHERE " + param + ";";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					for (int i = 0; i < reader.FieldCount - 1; ++i)
					{
						result += reader[i].ToString() + " | ";
					}
					result += reader[reader.FieldCount - 1].ToString() + "\n";
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

		public string getExaminationTypesString(SqlCommand command)
		{
			string result = "";
			command.CommandText = "SELECT * FROM Tbl_ExaminationTypes;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result += reader[0].ToString() + " | " + reader[1].ToString() + "\n";
				}
			}
			return result;
		}

		public SortedSet<ExaminationType> getExaminationTypes(SqlCommand command)
		{
			SortedSet<ExaminationType> setMedicalEquipments = new SortedSet<ExaminationType>();

			command.CommandText = "SELECT * FROM Tbl_ExaminationTypes;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					setMedicalEquipments.Add(new ExaminationType(Int32.Parse(reader[0].ToString()), reader[1].ToString()));
				}
			}
			return setMedicalEquipments;
		}

		public string getProtocolsString(SqlCommand command)
		{
			string result = "";
			command.CommandText = "SELECT * FROM Tbl_Protocols;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result += reader[0].ToString() + " | " + reader[1].ToString() + " | " +
						reader[3].ToString() + " | " + reader[4].ToString() + " | " + reader[5].ToString() + " | " + reader[6].ToString() + "\n";
				}
			}
			return result;
		}

		public SortedSet<Protocol> getProtocols(SqlCommand command)
		{
			SortedSet<Protocol> setProtocols = new SortedSet<Protocol>();

			command.CommandText = "SELECT * FROM Tbl_Protocols;";

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					setProtocols.Add(new Protocol(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(),
						Int32.Parse(reader[3].ToString()), Int32.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()),
						reader[6].ToString()));
				}
			}
			return setProtocols;
		}
	}
}
