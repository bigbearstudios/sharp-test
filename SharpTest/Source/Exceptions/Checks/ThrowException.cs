using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class ThrowException
	{
		internal static void Check(Expect expect)
		{
			try 
			{
				Action action = (Action)expect.TestObject;
				if(action != null)
				{
					try
					{
						action.Invoke();
						if(!expect.Reversed)
						{
							throw new Exception(String.Format("The object {0} ({1}) did not throw an exception", expect.TestObject, expect.Name));
						}
					}
					catch(Exception ex)
					{
						if(expect.Reversed)
						{
							ThrowThrownException(expect, ex);
						}
					}
				}
			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to an Action", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void ThrowThrownException(Expect expect, Exception ex)
		{
			throw new Exception(String.Format("The object {0} ({1}) threw an exception", expect.TestObject, expect.Name));
		}
	}
}

