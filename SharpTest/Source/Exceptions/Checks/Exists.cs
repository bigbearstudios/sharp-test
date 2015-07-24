using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Exists
	{
		internal static void Check(Expect expect)
		{
			if(expect.TestObject == null)
			{
				if(!expect.Reversed)
				{
					throw new Exception(String.Format("The object {0} ({1}) was not Ok", expect.TestObject, expect.Name));
				}
			}
			else
			{
				Type type = expect.TestObject.GetType();

				//Any value type is marked as 'existing'
				if(type.IsValueType)
				{
					if(expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) exists", expect.TestObject, expect.Name));
					}
				}
				else
				{
					if(expect.TestObject != null)
					{
						if(expect.Reversed)
						{
							throw new Exception(String.Format("The object {0} ({1}) exists", expect.TestObject, expect.Name));
						}
					}
					else
					{
						if(!expect.Reversed)
						{
							throw new Exception(String.Format("The object {0} ({1}) doesn't exist", expect.TestObject, expect.Name));
						}
					}
				}
			}
		}
	}
}

