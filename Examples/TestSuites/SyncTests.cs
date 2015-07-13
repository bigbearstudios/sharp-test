using System;
using System.Threading.Tasks;

using SharpTest;

namespace Examples
{
	[TestAttribute("Something")]
	public class SyncTests : TestSuite
	{
		public SyncTests()
		{
			
		}

		public void TestSomething()
		{

		}

		public Task TestSomethingAsync()
		{
			return null;
		}
	}
}

