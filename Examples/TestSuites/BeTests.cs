using System;

using SharpTest;
using SharpTest.Exceptions;

namespace Examples
{
	public class BeTests : TestSuite
	{
		public BeTests()
		{
			
		}

		public void AtLeast()
		{
			new Expect(10).To.Be.AtLeast(9);
			new Expect(10.0f).To.Be.AtLeast(9.0f);
			new Expect(10.0).To.Be.AtLeast(9.0);
		}

		public void NotAtLeast()
		{
			new Expect(8).To.Not.Be.AtLeast(9);
			new Expect(8.0f).To.Not.Be.AtLeast(9.0f);
			new Expect(8.0).To.Not.Be.AtLeast(9.0);
		}

		public void Above()
		{
			new Expect(10).To.Be.Above(5);
			new Expect(10.0f).To.Be.Above(5.0f);
			new Expect(10.0).To.Be.Above(5.0);
		}

		public void NotAbove()
		{
			new Expect(4).To.Not.Be.Above(5);
			new Expect(4.0f).To.Not.Be.Above(5.0f);
			new Expect(4.0).To.Not.Be.Above(5.0);
		}

		public void Ok()
		{
			new Expect(1.0).To.Be.Ok();
			new Expect(true).To.Be.Ok();
			new Expect(new object()).To.Be.Ok();
		}

		public void NotOk()
		{
			new Expect(0.0).To.Not.Be.Ok();
			new Expect(false).To.Not.Be.Ok();
			new Expect(null).To.Not.Be.Ok();
		}

		public void EqualTo()
		{
			new Expect(1.0).To.Be.EqualTo(1.0);
			new Expect(true).To.Be.EqualTo(true);

			object testObject = new object();
			new Expect(testObject).To.Be.EqualTo(testObject);
		}

		public void NotEqualTo()
		{
			new Expect(2.0).To.Not.Be.EqualTo(1.0);
			new Expect(false).To.Not.Be.EqualTo(true);
			new Expect(new object()).To.Not.Be.EqualTo(new object());
		}

		public void Null()
		{
			new Expect(null).To.Be.Null();
		}

		public void NotNull()
		{
			new Expect(new object()).To.Not.Be.Null();
		}

		public void True()
		{
			new Expect(1.0).To.Be.True();
			new Expect(true).To.Be.True();
			new Expect(new object()).To.Be.True();
		}

		public void NotTrue()
		{
			new Expect(0.0).To.Not.Be.True();
			new Expect(null).To.Not.Be.True();
			new Expect(false).To.Not.Be.True();
		}

		public void Within()
		{
			new Expect(5).To.Be.Within(4, 6);
			new Expect(5.0f).To.Be.Within(4.0f, 6.0f);
			new Expect(5.0).To.Be.Within(4.0, 6.0);
		}

		public void NotWithin()
		{
			new Expect(2).To.Not.Be.Within(4, 6);
			new Expect(2.0f).To.Not.Be.Within(4.0f, 6.0f);
			new Expect(2.0).To.Not.Be.Within(4.0, 6.0);
		}

		public void Between()
		{
			new Expect(5).To.Be.Between(4, 6);
			new Expect(5.0f).To.Be.Between(4.0f, 6.0f);
			new Expect(5.0).To.Be.Between(4.0, 6.0);
		}

		public void NotBetween()
		{
			new Expect(2).To.Not.Be.Between(4, 6);
			new Expect(2.0f).To.Not.Be.Between(4.0f, 6.0f);
			new Expect(2.0).To.Not.Be.Between(4.0, 6.0);
		}

		public void CloseTo()
		{
			new Expect(4).To.Be.CloseTo(5, 2);
			new Expect(4.0f).To.Be.CloseTo(5.0f, 2.0f);
			new Expect(4.0).To.Be.CloseTo(5.0, 2.0);
		}

		public void NotCloseTo()
		{
			new Expect(1).To.Not.Be.CloseTo(5, 2);
			new Expect(1.0f).To.Not.Be.CloseTo(5.0f, 2.0f);
			new Expect(1.0).To.Not.Be.CloseTo(5.0, 2.0);
		}
	}
}

