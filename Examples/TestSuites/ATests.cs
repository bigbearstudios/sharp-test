using System;

using SharpTest;
using SharpTest.Exceptions;

namespace Examples
{
	public class ATests : TestSuite
	{
		public void Length()
		{
			new Expect(new int[]{ }).To.Have.A.Length.EqualTo(0);
			new Expect(new int[]{ 1, 2, 3, 4, 5 }).To.Have.A.Length.EqualTo(5);
		}
	}
}

