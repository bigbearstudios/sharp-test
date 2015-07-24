using System;
using System.Reflection;

namespace SharpTest.Exceptions.Checks
{
	public static class Contains
	{
		internal static void Check(Expect expect, Object contains)
		{
			//Check to see if we can respond to 'contains' method
			if(expect.TestObject != null)
			{
				try
				{
					Type type = expect.TestObject.GetType();
					MethodInfo info = type.GetMethod("Contains");
					if(info != null)
					{
						Boolean result = (Boolean)info.Invoke(expect.TestObject, new object[]{ contains });
						if(result)
						{
							if(expect.Reversed)
							{
								throw new Exception(String.Format("The object {0} ({1}) did not contain {2}", expect.TestObject, expect.Name, contains));
							}
						}
						else 
						{
							if(!expect.Reversed)
							{
								throw new Exception(String.Format("The object {0} ({1}) contained {2}", expect.TestObject, expect.Name, contains));
							}
						}
					}
					else
					{
						throw new Exception(String.Format("The object {0} ({1}) could not be be checked if it contains {2}", expect.TestObject, expect.Name, contains));
					}
				}
				catch(AmbiguousMatchException ex)
				{
					ex.ToString();
					throw new Exception(String.Format("The object {0} ({1}) could not be be checked if it contains {2}", expect.TestObject, expect.Name, contains));
				}
			}
			else
			{
				throw new Exception(String.Format("The object {0} ({1}) was null and thus could not be be checked if it contains {2}", expect.TestObject, expect.Name, contains));
			}
		}
	}
}

