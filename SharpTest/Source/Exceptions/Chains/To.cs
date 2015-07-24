using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class To : Chain
	{
		public To(Expect expect) : base(expect)
		{
			
		}

		public Be Be
		{
			get 
			{
				return new Be(Expect);
			} 
		}

		public ToNot Not
		{
			get 
			{
				return new ToNot(Expect);
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

		//Ideas for V1.2
		/*

		//Would check the string or the first value in an array
		public void StartsWith(Object startsWith)
		{

		}

		//Would check the strong or the end value of an array
		public void EndsWith()
		{

		}

		*/
	}
}

