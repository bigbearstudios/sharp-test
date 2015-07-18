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
	}
}

