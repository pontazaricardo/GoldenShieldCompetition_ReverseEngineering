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

			foreach (Answer answer in answersToUse)
			{
				answers.Add(answer);
			}
		}

		public CorrectAnswers()
		{
			answers = new List<Answer>();
		}

		#region Constructor based on ExampleList

		public CorrectAnswers(ExampleList exampleListToUse)
		{
			answers = new List<Answer>();

			List<Answer> answersFromExamples = ConvertExamplesToAnswers(exampleListToUse.examples);

			foreach (Answer answer in answersFromExamples)
			{
				answers.Add(answer);
			}
		}


		#endregion

		public List<Answer> ConvertExamplesToAnswers(List<Example> examplesToUse)
		{
			List<Answer> answersToReturn = new List<Answer>();

			foreach (Example example in examplesToUse)
			{
				answersToReturn.Add(new Answer(example.parameter01, example.parameter02, example.result));
			}

			return answersToReturn;
		}




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
			parameter01 = -2;
			parameter02 = -2;
			result = false;
		}
	}

}
