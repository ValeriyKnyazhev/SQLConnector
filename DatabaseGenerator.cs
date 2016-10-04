using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	class DatabaseGenerator
	{
		public static IList<string> DOCTOR_COLUMN_NAMES;
		public static IList<string> PATIENT_COLUMN_NAMES;

		private static DateTime BIRTHDAY_START_RANGE = new DateTime(1900, 1, 1);
		private static DateTime BIRTHDAY_END_RANGE = new DateTime(2000, 1, 1);

		private static int GENDER_NUMBER = 2;
		private static int AMBULATOR_CARD_MAX_NUMBER = Int32.MaxValue;

		public static string DOCTORS_TABLE_NAME = "Tbl_Doctors";
		public static string PATIENTS_TABLE_NAME = "Tbl_Patients";

		static DatabaseGenerator()
		{
			DOCTOR_COLUMN_NAMES = new List<string>();
			DOCTOR_COLUMN_NAMES.Add("dct_fullname");
			DOCTOR_COLUMN_NAMES.Add("dct_status");

			PATIENT_COLUMN_NAMES = new List<string>();
			PATIENT_COLUMN_NAMES.Add("pat_fullname");
			PATIENT_COLUMN_NAMES.Add("pat_gender");
			PATIENT_COLUMN_NAMES.Add("pat_birthdate");
			PATIENT_COLUMN_NAMES.Add("pat_numberambulatorycard");
		}

		private static IList<string> GetNextDoctorTableRow()
		{
			IList<string> row = new List<string>();
			row.Add(InsertValuesHelper.GetWrappedString(RandomUtil.GetNextRandomName()));
			row.Add(InsertValuesHelper.GetWrappedBool(RandomUtil.GetNextBool()));

			return row;
		}

		public static IList<IList<string>> GetDoctorTableValues(int number)
		{
			IList<IList<string>> values = new List<IList<string>>();
			for (int i = 0; i < number; ++i)
			{
				values.Add(GetNextDoctorTableRow());
			}

			return values;
		}

		private static IList<string> GetNextPatientRow()
		{
			IList<string> row = new List<string>();
			row.Add(InsertValuesHelper.GetWrappedString(RandomUtil.GetNextRandomName()));
			row.Add(InsertValuesHelper.GetWrappedInt(RandomUtil.GetNextInt(2)));
			row.Add(InsertValuesHelper.GetWrappedDate(
				RandomUtil.GetNextDate(BIRTHDAY_START_RANGE, BIRTHDAY_END_RANGE)));
			row.Add(InsertValuesHelper.GetWrappedInt(RandomUtil.GetNextInt(AMBULATOR_CARD_MAX_NUMBER)));

			return row;
		}

		public static IList<IList<string>> GetPatientTableValues(int number)
		{
			IList<IList<string>> values = new List<IList<string>>();
			for (int i = 0; i < number; ++i)
			{
				values.Add(GetNextPatientRow());
			}

			return values;
		}
	}
}
