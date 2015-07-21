using System;

using SharpTest;
using SharpTest.Exceptions;

namespace Examples
{
	public class ToTests : TestSuite
	{
		public void ThrowException()
		{
			new Expect((Action)(() =>
			{
				throw new Exception();
			})).To.ThrowException();

			new Expect((Action)(() =>
			{
				new Expect(45).To.ThrowException();
			})).To.ThrowException();
		}

		public void NotThrowException()
		{
			new Expect((Action)(() =>
			{

			})).To.Not.ThrowException();
		}
	}
}

