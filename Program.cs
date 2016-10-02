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

		static void Main(string[] args)
		{
			string login = "val_guest";

			string Connect = "Data Source=VALERIYPC\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=UltraSoundProtocolsDB; User=" + login + "; Password=hf94hd78";
			string result = "";
			try
			{
				SqlConnection myConnection = new SqlConnection(Connect);
				SqlCommand myCommand = myConnection.CreateCommand();
				myConnection.Open(); //Устанавливаем соединение с базой данных.

				SQLConnector sqlConnector = new SQLConnector();

				result = sqlConnector.getDoctorsString(myCommand);
				SortedSet<Doctor> doctors = sqlConnector.getDoctors(myCommand);
				Console.WriteLine(result);

				result = sqlConnector.getPatientsString(myCommand);
				SortedSet<Patient> patients = sqlConnector.getPatients(myCommand);
				Console.WriteLine(result);

				myConnection.Close(); //Обязательно закрываем соединение!
				myConnection.Dispose();
			}
			catch (Exception e) { Console.WriteLine(e.Message + " я ввел: " + login + ", но где то накосячил"); }

		}



		
	}
}
