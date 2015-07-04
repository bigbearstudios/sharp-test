using System;
using System.Threading.Tasks;

using SharpTest;

namespace Examples
{
	public class Program: TestRunner
	{
		public static void Main(string[] args)
		{
			TestRunner.Start<Program>();
		}

		public override Task BeforeAsync ()
		{
			//Do some Async stuff
			return new Task(() => {});
		}

		public override Task AfterAsync ()
		{
			//Do some Async stuff
			return new Task(() => {});
		}
	}
}

