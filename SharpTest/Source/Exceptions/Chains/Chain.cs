using System;

namespace SharpTest.Exceptions.Chains
{
	public class Chain
	{
		private Expect expect = null;

		internal Expect Expect
		{
			get { return this.expect; }
			set { this.expect = value; }
		}

		public Chain(Expect expect)
		{
			Expect = expect;
		}
	}
}

