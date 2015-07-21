using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Above
	{
		internal static void Check(Expect expect, int against)
		{
			try
			{
				Int32 convertedTest = Convert.ToInt32(expect.TestObject);
				if(convertedTest > against)
				{
					if(expect.Reversed)
					{
						ThrowAboveException(expect, against);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotAboveException(expect, against);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Int32", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void Check(Expect expect, float against)
		{
			try
			{
				float convertedTest = Convert.ToSingle(expect.TestObject);
				if(convertedTest > against)
				{
					if(expect.Reversed)
					{
						ThrowAboveException(expect, against);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotAboveException(expect, against);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Single", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void Check(Expect expect, double against)
		{
			try
			{
				Double convertedTest = Convert.ToDouble(expect.TestObject);
				if(convertedTest > against)
				{
					if(expect.Reversed)
					{
						ThrowAboveException(expect, against);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotAboveException(expect, against);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Double", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void ThrowAboveException(Expect expect, Object against)
		{
			throw new Exception(String.Format("The object {0} ({1}) was above {2}", expect.TestObject, expect.Name, against));
		}

		internal static void ThrowNotAboveException(Expect expect, Object against)
		{
			throw new Exception(String.Format("The object {0} ({1}) was below or equal to {2}", expect.TestObject, expect.Name, against));
		}
	}
}

