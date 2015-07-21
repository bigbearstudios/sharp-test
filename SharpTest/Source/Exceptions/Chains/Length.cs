using System;
using System.Reflection;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class Length : Chain
	{
		//Pre process if Length can be used
		public Length(Expect expect) : base(expect)
		{
			ParseLengthMethod();
			Expect = expect;
		}

		private void ParseLengthMethod()
		{
			try
			{
				Type type = Expect.TestObject.GetType();
				MethodInfo info = type.GetMethod("get_Length");
				if(info != null)
				{
					Expect.TestObject = info.Invoke(Expect.TestObject, new object[]{});
				}
				else
				{
					ThrowMethodException(null);
				}
			}
			catch(AmbiguousMatchException ex)
			{
				ThrowMethodException(ex);
			}
		}

		private void ThrowMethodException(Exception ex)
		{
			throw new Exception(String.Format("The object {0} ({1}) was not able to respond to the method Length", Expect.TestObject, Expect.Name));
		}

		public void EqualTo(int toEqual)
		{
			Checks.EqualTo.Check(Expect, toEqual);
		}

		public void AtLeast(int atleast)
		{
			Checks.AtLeast.Check(Expect, atleast);
		}

		public void Above(int above)
		{
			Checks.Above.Check(Expect, above);
		}

		public void Below(int below)
		{
			Checks.Below.Check(Expect, below);
		}

		public void Within(int lower, int higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}
		public void Between(int lower, int higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}

		public void CloseTo(int closeTo, int delta)
		{
			Checks.CloseTo.Check(Expect, closeTo, delta);
		}
	}
}

