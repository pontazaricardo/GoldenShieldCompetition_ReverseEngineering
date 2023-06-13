using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestCrytpoLibrary01
{
	public class TeamData
	{
		public string ID;
		public string challengeID;
		public bool passedTests;

		public CorrectAnswers expectedAnswers;
		



		public TeamData(string ID) 
		{ 
			this.ID = ID;
			passedTests = false;

			expectedAnswers = new CorrectAnswers();
		}

		public void setExpectedAnswers(CorrectAnswers correctAnswers) 
		{
			expectedAnswers.answers = new List<Answer>();

			foreach(Answer answer in correctAnswers.answers)
			{
				expectedAnswers.answers.Add(answer);
			}
		}

		public bool 



	}
}
