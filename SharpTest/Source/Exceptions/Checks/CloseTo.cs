using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class CloseTo
	{
		internal static void Check(Expect expect, int closeTo, int delta)
		{
			try
			{
				Int32 convertedTest = Convert.ToInt32(expect.TestObject);
				if(convertedTest > (closeTo - delta) && convertedTest < (closeTo + delta))
				{
					if(expect.Reversed)
					{
						ThrowCloseToException(expect, closeTo);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotCloseToException(expect, closeTo);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Int32", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void Check(Expect expect, float closeTo, float delta)
		{
			try
			{
				float convertedTest = Convert.ToSingle(expect.TestObject);
				if(convertedTest > (closeTo - delta) && convertedTest < (closeTo + delta))
				{
					if(expect.Reversed)
					{
						ThrowCloseToException(expect, closeTo);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotCloseToException(expect, closeTo);
					}
				}

			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Int32", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void Check(Expect expect, double closeTo, double delta)
		{
			try
			{
				double convertedTest = Convert.ToDouble(expect.TestObject);
				if(convertedTest > (closeTo - delta) && convertedTest < (closeTo + delta))
				{
					if(expect.Reversed)
					{
						ThrowCloseToException(expect, closeTo);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotCloseToException(expect, closeTo);
					}
				}

			}
			catch(InvalidCastException ex)
			{
				throw new Exception(String.Format("The object {0} ({1}) Could not be cast to a Int32", expect.TestObject, expect.Name), ex);
			}
		}

		internal static void ThrowCloseToException(Expect expect, Object closeTo)
		{
			throw new Exception(String.Format("The object {0} ({1}) was close to {2}", expect.TestObject, expect.Name, closeTo));
		}

		internal static void ThrowNotCloseToException(Expect expect, Object closeTo)
		{
			throw new Exception(String.Format("The object {0} ({1}) was not close to {2}", expect.TestObject, expect.Name, closeTo));
		}
	}
}

