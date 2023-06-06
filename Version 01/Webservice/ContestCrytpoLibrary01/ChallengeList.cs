using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContestCrytpoLibrary01
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

		public ChallengeList	()
		{
			challenges = new List<Challenge>();
			testID = "";
		}
	}

	public class Challenge
	{
		[XmlElementAttribute("parameter01")]
		public int parameter01;

		[XmlElementAttribute("parameter02")]
		public int parameter02;

		public Challenge(int parameter01, int parameter02, bool result)
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
