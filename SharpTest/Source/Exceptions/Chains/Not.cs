using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class Not : Chain
	{
		public Not(Expect expect) : base(expect)
		{
			Expect.Reversed = !Expect.Reversed;
		}

		public NotTo To
		{
			get
			{
				return new NotTo(Expect);
			}
		}
	}
}

