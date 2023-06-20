using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContestCryptoLibrary
{
	public class ChallengeList
	{
		[XmlElementAttribute("testID")]
		public string testID = "";

		public List<Challenge> challenges;

		public ChallengeList(List<Challenge> challengesToUse, string testIDToUse)
		{
			challenges = new List<Challenge>();
			testID = testIDToUse;

			foreach (Challenge challenge in challengesToUse)
			{
				challenges.Add(challenge);
			}
		}

		public ChallengeList()
		{
			challenges = new List<Challenge>();
			testID = "";
		}

		public ChallengeList(ExampleList exampleList, string testIDToUse)
		{
			challenges = new List<Challenge>();
			testID = testIDToUse;

			foreach (Example example in exampleList.examples)
			{
				Challenge challenge = new Challenge(example.parameter01, example.parameter02);
				challenges.Add(challenge);
			}
		}
	}

	public class Challenge
	{
		[XmlElementAttribute("parameter01")]
		public int parameter01;

		[XmlElementAttribute("parameter02")]
		public int parameter02;

		public Challenge(int parameter01, int parameter02)
		{
			this.parameter01 = parameter01;
			this.parameter02 = parameter02;
		}

		public Challenge()
		{
			parameter01 = -1;
			parameter02 = -1;
		}
	}
}
