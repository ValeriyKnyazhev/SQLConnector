using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnector
{
	class RandomUtil
	{
		private static Random random;

		private static IList<string> FIRST_NAMES;
		private static IList<string> LAST_NAMES;

		static RandomUtil()
		{
			random = new Random();

			FIRST_NAMES = new List<string>();
			FIRST_NAMES.Add("Ivan");
			FIRST_NAMES.Add("Valeriy");
			FIRST_NAMES.Add("Aleksey");
			FIRST_NAMES.Add("Igor");
			FIRST_NAMES.Add("Petr");
			FIRST_NAMES.Add("Yuriy");
			FIRST_NAMES.Add("Gregor");
			FIRST_NAMES.Add("Mathew");
			FIRST_NAMES.Add("Aleksandr");
			FIRST_NAMES.Add("Maria");
			FIRST_NAMES.Add("Tatiana");
			FIRST_NAMES.Add("Violeta");
			FIRST_NAMES.Add("Ludmila");
			FIRST_NAMES.Add("Galina");
			FIRST_NAMES.Add("Natalia");
			FIRST_NAMES.Add("Lubov");
			FIRST_NAMES.Add("Nadezhda");
			FIRST_NAMES.Add("Kis");
			FIRST_NAMES.Add("Mish");
			FIRST_NAMES.Add("Lev");
			FIRST_NAMES.Add("Olen");
			FIRST_NAMES.Add("Orel");

			LAST_NAMES = new List<string>();
			LAST_NAMES.Add("Petrov");
			LAST_NAMES.Add("Sidorov");
			LAST_NAMES.Add("Blazgozhakovski");
			LAST_NAMES.Add("Ivanov");
			LAST_NAMES.Add("Putin");
			LAST_NAMES.Add("Medvedev");
			LAST_NAMES.Add("Arshavin");
			LAST_NAMES.Add("Abramov");
			LAST_NAMES.Add("Aksyonov");
			LAST_NAMES.Add("Bykov");
			LAST_NAMES.Add("Zhukov");
			LAST_NAMES.Add("Kondratiev");
			LAST_NAMES.Add("Mamontov");
			LAST_NAMES.Add("Orlov");
			LAST_NAMES.Add("Savin");
			LAST_NAMES.Add("Tarasov");
			LAST_NAMES.Add("Sharapov");
			LAST_NAMES.Add("Azazov");
		}

		public static int GetNextInt(int maxValue)
		{
			return random.Next(maxValue);
		}

		private static string GetRandomFirstName()
		{
			int nextInt = GetNextInt(FIRST_NAMES.Count);
			return FIRST_NAMES[nextInt];
		}

		private static string GetRandomLastName()
		{
			int nextInt = GetNextInt(LAST_NAMES.Count);
			return LAST_NAMES[nextInt];
		}

		public static string GetNextRandomName()
		{
			return GetRandomFirstName() + ' ' + GetRandomLastName();
		}

		public static bool GetNextBool()
		{
			return GetNextBool(50);
		}

		/**
         * trueProbability from 0 to 100
         */
		public static bool GetNextBool(int trueProbability)
		{
			if (trueProbability < 0 || trueProbability > 100)
			{
				throw new ArgumentException("trueProbability < 0 || trueProbability > 100");
			}

			int nextInt = GetNextInt(100);

			return (nextInt < trueProbability);
		}

		public static DateTime GetNextDate(DateTime begin, DateTime end)
		{
			int range = (end - begin).Days;
			int rand = GetNextInt(range);

			return begin.AddDays(rand);
		}
	}
}
