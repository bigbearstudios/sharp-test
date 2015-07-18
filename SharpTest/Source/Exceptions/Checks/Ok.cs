using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Ok
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

				/*
				 * We need to check to see if we have a value type in order to see how to check for 'ok'.
				 * For value types we will attempt to conver them to a bool in order to see if the
				 */
				if(type.IsValueType)
				{
					try
					{
						if(Convert.ToBoolean(expect.TestObject))
						{
							if(expect.Reversed)
							{
								throw new Exception(String.Format("The object {0} ({1}) was Ok", expect.TestObject, expect.Name));
							}
						}
						else
						{
							if(!expect.Reversed)
							{
								throw new Exception(String.Format("The object {0} ({1}) was not Ok", expect.TestObject, expect.Name));
							}
						}
					}
					catch(InvalidCastException ex)//Picking up on the invalid item
					{
						if(!expect.Reversed)
						{
							throw new Exception(String.Format("The object {0} ({1}) was not Ok, threw internal exception {2}", expect.TestObject, expect.Name, ex.Message));
						}
					}
				}
				else
				{
					if(expect.TestObject != null)
					{
						if(expect.Reversed)
						{
							throw new Exception(String.Format("The object {0} ({1}) was Ok", expect.TestObject, expect.Name));
						}
					}
					else
					{
						if(!expect.Reversed)
						{
							throw new Exception(String.Format("The object {0} ({1}) was not Ok", expect.TestObject, expect.Name));
						}
					}
				}
			}
		}
	}
}

