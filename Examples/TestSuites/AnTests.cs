using System;

using SharpTest;
using SharpTest.Exceptions;

namespace Examples
{
	public class AnTests : TestSuite
	{
		public AnTests()
		{
			
		}

		public void InstanceOf()
		{
			Int32 toTest = new Int32();
			new Expect(toTest).To.Be.An.InstanceOf(typeof(Int32));
		}
	}
}

