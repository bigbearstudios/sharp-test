using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Below
	{
		internal static void Check(Expect expect, int against)
		{
			try
			{
				Int32 convertedTest = Convert.ToInt32(expect.TestObject);
				if(convertedTest < against)
				{
					if(expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was below {2}", expect.TestObject, expect.Name, against));
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was above or equal to {2}", expect.TestObject, expect.Name, against));
					}
				}
			}
			catch(InvalidCastException ex)//Picking up on the invalid item
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Int32", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void Check(Expect expect, float against)
		{
			try
			{
				float convertedTest = Convert.ToSingle(expect.TestObject);
				if(convertedTest < against)
				{
					if(expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was below {2}", expect.TestObject, expect.Name, against));
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was above or equal to {2}", expect.TestObject, expect.Name, against));
					}
				}
			}
			catch(InvalidCastException ex)//Picking up on the invalid item
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Single", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void Check(Expect expect, double against)
		{
			try
			{
				Double convertedTest = Convert.ToDouble(expect.TestObject);
				if(convertedTest < against)
				{
					if(expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was below {2}", expect.TestObject, expect.Name, against));
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was above or equal to {2}", expect.TestObject, expect.Name, against));
					}
				}
			}
			catch(InvalidCastException ex)//Picking up on the invalid item
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Double", expect.TestObject, expect.Name), ex);
			}
		}
	}
}

