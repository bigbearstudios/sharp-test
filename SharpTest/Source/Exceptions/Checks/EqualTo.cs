using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class EqualTo
	{
		internal static void Check(Expect expect, Object against)
		{
			if(Object.Equals(expect.TestObject, against))//The items are equal
			{
				if(expect.Reversed)//Throw exception if reversed
				{
					throw new Exception(String.Format("The object {0} ({1}) was equal to {2}", expect.TestObject, expect.Name, against));
				}
			}
			else//The items aren't equal
			{
				if(!expect.Reversed)//Throw exception if reversed
				{
					throw new Exception(String.Format("The object {0} ({1}) was not equal to {2}", expect.TestObject, expect.Name, against));
				}
			}
		}
	}
}

