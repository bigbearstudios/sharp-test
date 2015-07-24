using System;
using System.Collections.Generic;

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

		public void Exist()
		{
			new Expect(new object()).To.Exist();
			new Expect(false).To.Exist();
			new Expect(1.0).To.Exist();
			new Expect(34).To.Exist();
			new Expect(0).To.Exist();
		}

		public void NotExist()
		{
			new Expect(null).To.Not.Exist();
		}

		public void Contain()
		{
			new Expect("thisbeastring").To.Contain("beast");
			new Expect(new List<int>{ 1, 2, 3, 4, 5 }).To.Contain(3);
		}

		public void ContainThrow()
		{
			new Expect((Action)(() =>
			{
				new Expect("thisbeastring").To.Contain("chinese");
			})).To.ThrowException();
		}

		public void NotContain()
		{
			new Expect("thisbeastring").To.Not.Contain("chinese");
			new Expect(new List<int>{ 1, 2, 3, 4, 5 }).To.Not.Contain(10);
		}

		public void NotContainThrow()
		{
			new Expect((Action)(() =>
			{
				new Expect("thisbeastring").To.Not.Contain("beast");
				new Expect(new List<int>{ 1, 2, 3, 4, 5 }).To.Not.Contain(3);
			})).To.ThrowException();
		}
	}
}

