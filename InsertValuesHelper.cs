using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLConnector
{
	class InsertValuesHelper
	{
		private static string INSERT_INTO = "INSERT INTO";
		private static string SPACE = " ";
		private static string OPEN_BRACKET = "(";
		private static string CLOSE_BRACKET = ")";
		private static string VALUES = "VALUES";
		private static string COMMA = ",";
		private static string SEMICOLON = ";";
		private static string QUOTE = "'";
		private static string DOT = ".";

		private static string BOOL_ZERO = "0";
		private static string BOOL_ONE = "1";

		private static string GetInsertCommandString(string tableName,
								  IList<string> columnNames,
								  IList<IList<string>> values)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(INSERT_INTO).Append(SPACE);

			builder.Append(tableName).Append(OPEN_BRACKET);
			for (int i = 0; i < columnNames.Count; ++i)
			{
				builder.Append(columnNames[i]);
				if (i != columnNames.Count - 1)
				{
					builder.Append(COMMA).Append(SPACE);
				}
			}
			builder.Append(CLOSE_BRACKET).Append(SPACE);

			builder.Append(VALUES).Append(SPACE);
			for (int rowIndex = 0; rowIndex < values.Count; ++rowIndex)
			{
				if (values[rowIndex].Count != columnNames.Count)
				{
					throw new ArgumentException("values[rowIndex].Count != columnNames.Count");
				}

				builder.Append(OPEN_BRACKET);
				for (int columnIndex = 0; columnIndex < values[rowIndex].Count; ++columnIndex)
				{
					builder.Append(values[rowIndex][columnIndex]);

					if (columnIndex != values[rowIndex].Count - 1)
					{
						builder.Append(COMMA).Append(SPACE);
					}
				}

				builder.Append(CLOSE_BRACKET);

				if (rowIndex != values.Count - 1)
				{
					builder.Append(COMMA).Append(SPACE);
				}
				else
				{
					builder.Append(SEMICOLON);
				}
			}

			Console.WriteLine(builder.ToString());

			return builder.ToString();
		}

		/**
         * Return inserted rows count
         */
		public static int Insert(string connectString,
								  string tableName,
								  IList<string> columnNames,
								  IList<IList<string>> values)
		{
			int affectedRows = 0;
			using (SqlConnection connection = new SqlConnection(connectString))
			{
				SqlCommand insertCommand = connection.CreateCommand();
				insertCommand.CommandText = GetInsertCommandString(tableName, columnNames, values);
				connection.Open();

				affectedRows = insertCommand.ExecuteNonQuery();
			}

			return affectedRows;
		}

		public static string GetWrappedString(string str)
		{
			return QUOTE + str + QUOTE;
		}

		public static string GetWrappedInt(int value)
		{
			return Convert.ToString(value);
		}

		public static string GetWrappedBool(bool value)
		{
			return value ? BOOL_ONE : BOOL_ZERO;
		}

		public static string GetWrappedDate(DateTime date)
		{
			return QUOTE + GetWrappedInt(date.Day) + DOT + GetWrappedInt(date.Month) + DOT + GetWrappedInt(date.Year) + QUOTE;
		}
	}
}
