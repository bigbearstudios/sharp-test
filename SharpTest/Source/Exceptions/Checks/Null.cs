using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Null
	{
		internal static void Check(Expect expect)
		{
			if(expect.TestObject == null)
			{
				if(expect.Reversed)
				{
					throw new Exception(String.Format("The object {0} ({1}) was Null", expect.TestObject, expect.Name));
				}
			}
		}
	}
}

