using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Within
	{
		internal static void Check(Expect expect, int lower, int higher)
		{
			try
			{
				Int32 convertedTest = Convert.ToInt32(expect.TestObject);
				if(convertedTest > lower && convertedTest < higher)
				{
					if(expect.Reversed)
					{
						ThrowInbetweenException(expect, lower, higher);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotInbetweenException(expect, lower, higher);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				if(!expect.Reversed)
				{
					ThrowAboveGenericException(expect, lower, higher, ex);
				}
			}
		}

		internal static void Check(Expect expect, float lower, float higher)
		{
			try
			{
				float convertedTest = Convert.ToSingle(expect.TestObject);
				if(convertedTest > lower && convertedTest < higher)
				{
					if(expect.Reversed)
					{
						ThrowInbetweenException(expect, lower, higher);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotInbetweenException(expect, lower, higher);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				if(!expect.Reversed)
				{
					ThrowAboveGenericException(expect, lower, higher, ex);
				}
			}
		}

		internal static void Check(Expect expect, double lower, double higher)
		{
			try
			{
				Double convertedTest = Convert.ToDouble(expect.TestObject);
				if(convertedTest > lower && convertedTest < higher)
				{
					if(expect.Reversed)
					{
						ThrowInbetweenException(expect, lower, higher);
					}
				}
				else
				{
					if(!expect.Reversed)
					{
						ThrowNotInbetweenException(expect, lower, higher);
					}
				}
			}
			catch(InvalidCastException ex)
			{
				if(!expect.Reversed)
				{
					ThrowAboveGenericException(expect, lower, higher, ex);
				}
			}
		}

		internal static void ThrowInbetweenException(Expect expect, Object lower, Object higher)
		{
			throw new Exception(String.Format("The object {0} ({1}) was inbetween {2} and {3}", expect.TestObject, expect.Name, lower, higher));
		}

		internal static void ThrowNotInbetweenException(Expect expect, Object lower, Object higher)
		{
			throw new Exception(String.Format("The object {0} ({1}) was not inbetween {2} and {3}", expect.TestObject, expect.Name,  lower, higher));
		}

		internal static void ThrowAboveGenericException(Expect expect, Object lower, Object higher, InvalidCastException ex)
		{
			throw new Exception(String.Format("The object {0} ({1}) was not able to be tested for 'above', threw internal exception {2}", expect.TestObject, expect.TestObject, ex.Message));
		}
	}
}

