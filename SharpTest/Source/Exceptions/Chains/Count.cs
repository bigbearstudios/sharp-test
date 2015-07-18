using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class Count : Chain
	{
		public Count(Expect expect) : base(expect)
		{
			Expect = expect;
		}
	}
}

