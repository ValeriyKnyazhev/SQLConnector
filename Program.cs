using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLConnector
{
	class Program
	{

		private static void addFields(string connectString,
								string tableName,
								IList<string> columnNames,
								IList<IList<string>> values)
		{
			InsertValuesHelper.Insert(connectString,
				tableName,
				columnNames,
				values);
		}

		static void Main(string[] args)
		{
			string login = "val_guest";

			string Connect = "Data Source=VALERIYPC\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=UltraSoundProtocolsDB; User=" + login + "; Password=hf94hd78";

			string result = "";
			try { 
				SqlConnection myConnection = new SqlConnection(Connect);
				SqlCommand myCommand = myConnection.CreateCommand();
				myConnection.Open(); //Устанавливаем соединение с базой данных.

				SQLConnector sqlConnector = new SQLConnector();

				addFields(Connect,
					DatabaseGenerator.DOCTORS_TABLE_NAME,
					DatabaseGenerator.DOCTOR_COLUMN_NAMES,
					DatabaseGenerator.GetDoctorTableValues(20));


				addFields(Connect,
					DatabaseGenerator.PATIENTS_TABLE_NAME,
					DatabaseGenerator.PATIENT_COLUMN_NAMES,
					DatabaseGenerator.GetPatientTableValues(100));

				result = sqlConnector.getDoctorsString(myCommand);
				SortedSet<Doctor> doctors = sqlConnector.getDoctors(myCommand);
				Console.WriteLine(result);

				result = sqlConnector.getPatientsString(myCommand);
				SortedSet<Patient> patients = sqlConnector.getPatients(myCommand);
				Console.WriteLine(result);

				result = sqlConnector.getMedicalEquipmentsString(myCommand);
				SortedSet<MedicalEquipment> medicalEquipments = sqlConnector.getMedicalEquipments(myCommand);
				Console.WriteLine(result);

				result = sqlConnector.getExaminationTypesString(myCommand);
				SortedSet<ExaminationType> examinationTypes = sqlConnector.getExaminationTypes(myCommand);
				Console.WriteLine(result);

				result = sqlConnector.getProtocolsString(myCommand);
				SortedSet<Protocol> protocols = sqlConnector.getProtocols(myCommand);
				Console.WriteLine(result);

				result = sqlConnector.getRandomTableString(myCommand, "Tbl_Doctors", "dct_fullname LIKE '%Valeriy%'");
				Console.WriteLine(result);

				myConnection.Close(); //Обязательно закрываем соединение!
				myConnection.Dispose();
			}
			catch (Exception e) { Console.WriteLine(e.Message + " я ввел: " + login + ", но где то накосячил"); }

		}



		
	}
}
