using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class Have : Chain
	{
		public Have(Expect expect) : base(expect)
		{

		}

		public A A
		{
			get
			{
				return new A(Expect);
			}
		}
	}
}

