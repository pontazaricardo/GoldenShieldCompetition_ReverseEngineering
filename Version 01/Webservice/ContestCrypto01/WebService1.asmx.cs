using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.Xml;

using ContestCrytpoLibrary01;


namespace ContestCrypto01
{
	/// <summary>
	/// Summary description for WebService1
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class WebService1 : System.Web.Services.WebService
	{

		[WebMethod]
		public string HelloWorld()
		{
			return "Hello World";
		}

		[WebMethod]
		public int addition(int a, int b)
		{
			


			return a + b;
		}


		public string GetExamples()
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



		public int multiplication(int a, int b)
		{
			return a * b;
		}
	}
}
