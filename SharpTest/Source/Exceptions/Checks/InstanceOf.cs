using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class InstanceOf
	{
		internal static void Check(Expect expect, Type type)
		{
			//If the object is null then unless the Type sent in is null then this has failed
			if(expect.TestObject == null)
			{
				//This is a success
				if(type == null)
				{
					if(expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was of type {2}", expect.TestObject, expect.Name, type));
					}
				}
			} 
			else
			{
				if(expect.TestObject.GetType().Equals(type))//We have a matching type
				{
					if(expect.Reversed)//Return Exception if its reversed
					{
						throw new Exception(String.Format("The object {0} ({1}) was of type {2}", expect.TestObject, expect.Name, type));
					}
				}
				else//We have different types
				{
					if(!expect.Reversed)//Return exception if its not reversed
					{
						throw new Exception(String.Format("The object {0} ({1}) was not of type {2}", expect.TestObject, expect.Name, type));
					}
				}
			}
		}
	}
}

