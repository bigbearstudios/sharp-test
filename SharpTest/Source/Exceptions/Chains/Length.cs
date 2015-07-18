using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class Length : Chain
	{
		public Length(Expect expect) : base(expect)
		{
			Expect = expect;
		}
	}
}

