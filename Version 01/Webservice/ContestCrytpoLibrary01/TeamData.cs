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

		



		public TeamData(string ID) 
		{ 
			this.ID = ID;
			passedTests = false;
		}


	}
}
