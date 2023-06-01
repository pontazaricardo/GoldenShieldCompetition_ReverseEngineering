using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContestCrytpoLibrary01
{
	public class ExampleList
	{
		//[XmlArrayItem("example")]

		[XmlElementAttribute("timestamp")]
		public string timestamp = "";

		public List<Example> examples;

		public ExampleList(List<Example> examplesToUse)
		{
			examples = new List<Example>();
			timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

			foreach (Example example in examplesToUse)
			{
				examples.Add(example);
			}
		}

		public ExampleList()
		{
			examples = new List<Example>();
		}
	}

	
	public class Example
	{
		[XmlElementAttribute("parameter01")]
		public int parameter01;

		[XmlElementAttribute("parameter02")]
		public int parameter02;

		[XmlElementAttribute("result")]
		public bool result;


		public Example(int parameter01, int parameter02, bool result) 
		{ 
			this.parameter01 = parameter01;
			this.parameter02 = parameter02;
				
			this.result = result;
		}

		public Example()
		{
			parameter01 = -1;
			parameter02 = -1;
			result = false;
		}
	}

}
