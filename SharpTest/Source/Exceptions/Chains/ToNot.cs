using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class ToNot : Chain
	{
		public ToNot(Expect expect) : base(expect)
		{
			Expect.Reversed = !Expect.Reversed;
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

		public void ThrowException()
		{
			Checks.ThrowException.Check(Expect);
		}

		public void Exist()
		{
			Checks.Exists.Check(Expect);
		}

		public void Contain(Object toContain)
		{
			Checks.Contains.Check(Expect, toContain);
		}
	}
}

