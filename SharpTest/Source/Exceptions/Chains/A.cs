using System;

namespace SharpTest.Exceptions.Chains
{
	public class A : Chain
	{
		public A(Expect expect) : base(expect)
		{

		}

		public Length Length
		{
			get
			{
				return new Length(Expect);
			}
		}

		public Count Count
		{
			get
			{
				return new Count(Expect);
			}
		}
	}
}

