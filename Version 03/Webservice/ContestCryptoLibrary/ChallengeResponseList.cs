using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContestCryptoLibrary
{
	public class ChallengeResponseList
	{
		[XmlElementAttribute("testID")]
		public string testID = "";

		public List<Response> responses;

		public ChallengeResponseList(List<Response> responsesToUse)
		{
			responses = new List<Response>();
			testID = "";

			foreach (Response response in responsesToUse)
			{
				responses.Add(response);
			}
		}

		public ChallengeResponseList()
		{
			responses = new List<Response>();
		}
	}


	public class Response
	{
		[XmlElementAttribute("parameter01")]
		public int parameter01;

		[XmlElementAttribute("parameter02")]
		public int parameter02;

		[XmlElementAttribute("result")]
		public bool result;


		public Response(int parameter01, int parameter02, bool result)
		{
			this.parameter01 = parameter01;
			this.parameter02 = parameter02;

			this.result = result;
		}

		public Response()
		{
			parameter01 = -1;
			parameter02 = -1;
			result = false;
		}
	}
}
