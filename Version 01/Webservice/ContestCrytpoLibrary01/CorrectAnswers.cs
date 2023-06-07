using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContestCrytpoLibrary01
{
	public class CorrectAnswers
	{
		public List<Answer> answers;

		public CorrectAnswers(List<Answer> answersToUse)
		{
			answers = new List<Answer>();

			foreach (Answer example in answersToUse)
			{
				answers.Add(example);
			}
		}

		public CorrectAnswers()
		{
			answers = new List<Answer>();
		}

		#region Constructor based on ExampleList




		#endregion






	}

	public class Answer
	{
		
		public int parameter01;
		public int parameter02;
		public bool result;

		public Answer(int parameter01, int parameter02, bool result)
		{
			this.parameter01 = parameter01;
			this.parameter02 = parameter02;

			this.result = result;
		}

		public Answer()
		{
			parameter01 = -1;
			parameter02 = -1;
			result = false;
		}
	}

}
