using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

using ContestCryptoLibrary;

namespace ContestConsoleDebugger
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			string exampleXML = GetExamples();

			string challenge01_team02 = GetChallenge("team02");

		}

		public static string GetExamples()
		{
			ContestSingleton singleton = ContestSingleton.Instance;
			string result = "";

			ExampleList exampleList = new ExampleList(singleton.generateOracleExampleList(20));

			var xmlserializer = new XmlSerializer(typeof(ExampleList));
			var stringWriter = new StringWriter();

			using (var writer = XmlWriter.Create(stringWriter))
			{
				xmlserializer.Serialize(writer, exampleList);
				result = stringWriter.ToString();
			}

			return result;
		}

		public static string GetChallenge(string teamID)
		{
			ContestSingleton singleton = ContestSingleton.Instance;
			string result = "";

			ExampleList exampleListToUse = new ExampleList(singleton.generateOracleExampleList(20));

			if (!singleton.teamsData.ContainsKey(teamID))
			{
				result = "Error: invalid team ID obtained.";
				return result;
			}

			//At this point, the teamID is valid

			string challengeID = String.Format("{0}_{1}", teamID,DateTime.Now.ToString("HHmmss"));

			singleton.teamsData[teamID].setExpectedAnswers(exampleListToUse);
			singleton.teamsData[teamID].setChallengeList(exampleListToUse, challengeID);

			var xmlserializer = new XmlSerializer(typeof(ChallengeList));
			var stringWriter = new StringWriter();

			using (var writer = XmlWriter.Create(stringWriter))
			{
				xmlserializer.Serialize(writer, singleton.teamsData[teamID].challengeList);
				result = stringWriter.ToString();
			}

			return result;
		}


		static void Main03(string[] args)
		{
			Console.WriteLine("Hello, World!");

			ContestSingleton singleton = ContestSingleton.Instance;

			ExampleList exampleList = new ExampleList(singleton.generateOracleExampleList(20));

			var xmlserializer = new XmlSerializer(typeof(ExampleList));
			var stringWriter = new StringWriter();

			string result = "";

			using (var writer = XmlWriter.Create(stringWriter))
			{
				xmlserializer.Serialize(writer, exampleList);
				result = stringWriter.ToString();
			}

			//XML deserializer
			try
			{
				using (TextReader reader = new StringReader(result))
				{
					ExampleList listObtained = (ExampleList)xmlserializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
			}


		}


		static void Main02(string[] args)
		{
			Console.WriteLine("Hello, World!");

			/*Primes.populatePrimes();
			List<int> primeNumbers = Primes.primeNumbers;

			Console.WriteLine(primeNumbers[0]);*/

			PrimesContainer primes = PrimesContainer.Instance;

			ExampleList exampleList = new ExampleList(new List<Example>() {
				new Example(1,2,true),
				new Example(2,3,false)
			});

			var xmlserializer = new XmlSerializer(typeof(ExampleList));
			var stringWriter = new StringWriter();

			string result = "";

			using (var writer = XmlWriter.Create(stringWriter))
			{
				xmlserializer.Serialize(writer, exampleList);
				result = stringWriter.ToString();
			}


		}
	}
}
