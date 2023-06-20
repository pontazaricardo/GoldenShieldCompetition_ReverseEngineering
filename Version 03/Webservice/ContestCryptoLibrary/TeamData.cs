using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestCryptoLibrary
{
	public class TeamData
	{
		public string teamID;
		public string challengeID;
		public bool passedTests;

		public CorrectAnswers expectedAnswers;
		public ChallengeList challengeList;

		public TeamData(string teamID)
		{
			this.teamID = teamID;
			this.challengeID = "Unassigned";
			passedTests = false;

			expectedAnswers = new CorrectAnswers();
			challengeList = new ChallengeList();
		}

		/*public void setExpectedAnswers(CorrectAnswers correctAnswers)
		{
			expectedAnswers.answers = new List<Answer>();

			foreach (Answer answer in correctAnswers.answers)
			{
				expectedAnswers.answers.Add(answer);
			}
		}*/

		public void setExpectedAnswers(ExampleList exampleList)
		{
			this.expectedAnswers = new CorrectAnswers(exampleList);
		}

		public void setChallengeList(ExampleList exampleList, string testIDToUse)
		{
			this.challengeList = new ChallengeList(exampleList, testIDToUse);
			this.challengeID = testIDToUse;
		}

		/*public bool compareWithStoredAnswers(ChallengeResponseList obtainedResults)
		{
			bool result = false;



			return result;
		}*/



	}
}
