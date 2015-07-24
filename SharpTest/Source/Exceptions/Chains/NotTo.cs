using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class NotTo : Chain
	{
		public NotTo(Expect expect) : base(expect)
		{

		}

		public Be Be
		{
			get
			{
				return new Be(Expect);
			}
		}

		public Have Have
		{
			get
			{
				return new Have(Expect);
			}
		}
	}
}

