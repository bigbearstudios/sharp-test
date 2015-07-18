using System;

namespace SharpTest.Exceptions.Checks
{
	internal static class Upto
	{
		internal static void Check(Object testObject, String name, int against, Boolean reversed)
		{
			try
			{
				Int32 convertedTest = Convert.ToInt32(testObject);
				if(convertedTest <= against)
				{
					if(reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was below or equal to {2}", testObject, name, against));
					}
				}
				else
				{
					if(!reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was above {2}", testObject, name, against));
					}
				}
			}
			catch(InvalidCastException ex)//Picking up on the invalid item
			{
				if(!reversed)
				{
					throw new Exception(String.Format("The object {0} ({1}) was not able to be tested for 'upto', threw internal exception {2}", testObject, name, ex.Message));
				}
			}
		}

		internal static void Check(Object testObject, String name, float against, Boolean reversed)
		{
			try
			{
				float convertedTest = Convert.ToSingle(testObject);
				if(convertedTest <= against)
				{
					if(reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was below or equal to {2}", testObject, name, against));
					}
				}
				else
				{
					if(!reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was above {2}", testObject, name, against));
					}
				}
			}
			catch(InvalidCastException ex)//Picking up on the invalid item
			{
				if(!reversed)
				{
					throw new Exception(String.Format("The object {0} ({1}) was not able to be tested for 'upto', threw internal exception {2}", testObject, name, ex.Message));
				}
			}
		}

		internal static void Check(Object testObject, String name, double against, Boolean reversed)
		{
			try
			{
				Double convertedTest = Convert.ToDouble(testObject);
				if(convertedTest <= against)
				{
					if(reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was below or equal to {2}", testObject, name, against));
					}
				}
				else
				{
					if(!reversed)
					{
						throw new Exception(String.Format("The object {0} ({1}) was above {2}", testObject, name, against));
					}
				}
			}
			catch(InvalidCastException ex)//Picking up on the invalid item
			{
				if(!reversed)
				{
					throw new Exception(String.Format("The object {0} ({1}) was not able to be tested for 'upto', threw internal exception {2}", testObject, name, ex.Message));
				}
			}
		}
	}
}

