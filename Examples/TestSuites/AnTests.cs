using System;

using SharpTest;
using SharpTest.Exceptions;

namespace Examples
{
	public class AnTests : TestSuite
	{
		public void InstanceOf()
		{
			new Expect(new Int32()).To.Be.An.InstanceOf(typeof(Int32));
		}
	}
}

