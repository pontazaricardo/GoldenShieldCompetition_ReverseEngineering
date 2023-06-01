
using ContestCrytpoLibrary01;
using System.Xml;
using System.Xml.Serialization;

namespace ContestConsoleDebugger01
{
	internal class Program
	{
		static void Main(string[] args)
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
				result= stringWriter.ToString();
			}


		}
	}
}