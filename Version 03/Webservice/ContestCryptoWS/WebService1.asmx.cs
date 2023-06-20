using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.Xml;

using ContestCryptoLibrary;

namespace ContestCryptoWS
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

		[WebMethod]
		public string GetChallenge(string teamID)
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

			string challengeID = String.Format("{0}_{1}", teamID, DateTime.Now.ToString("HHmmss"));

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
	}
}
