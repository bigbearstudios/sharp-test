using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class An : Chain
	{
		public An(Expect expect) : base(expect)
		{

		}

		public void InstanceOf(Type type)
		{
			Checks.InstanceOf.Check(Expect, type);
		}
	}
}

