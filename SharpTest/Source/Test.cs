using System;

using SharpTest.Results;

namespace SharpTest
{
	/// <summary>
	/// Test
	/// The front facing Test interface. This allows the developer to recieve the Test through the 
	/// BeforeEach/AfterEach inside of the TestSuite
	/// </summary>
	public sealed class Test
	{
		private String name = null;
		private String description = null;
		private TestFormat format = TestFormat.Run;
		private UInt32 order = 0;

		private TestResult result;


		public String Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public String Description
		{
			get { return this.description; }
			set { this.description = value; }
		}

		public TestFormat Format
		{
			get { return this.format; }
			set { this.format = value; }
		}

		public UInt32 Order
		{
			get { return this.order; }
			set { this.order = value; }
		}

		public Test()
		{
			
		}
	}
}

