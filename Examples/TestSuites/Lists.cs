using System;

using SharpTest;

namespace Examples
{
	[TestAttribute()]
	public class Lists : TestSuite
	{
		public Lists ()
		{

		}

		public override void BeforeAll ()
		{
			base.BeforeAll ();
		}

		public override void AfterAll ()
		{
			base.AfterAll ();
		}

		public override void AfterEach (Test test)
		{
			base.AfterEach (test);
		}

		public override void BeforeEach (Test test)
		{
			base.BeforeEach (test);
		}
	}
}

