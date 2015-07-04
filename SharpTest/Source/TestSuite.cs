using System;

namespace SharpTest
{
	public class TestSuite
	{
		private String name = null;
		private String description = null;
		private TestFormat format = TestFormat.Run;
		private UInt32 order = 0;

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

		public TestSuite()
		{
			
		}

		public virtual void BeforeAll()
		{

		}

		public virtual void AfterAll()
		{

		}

		public virtual void BeforeEach(Test test)
		{

		}

		public virtual void AfterEach(Test test)
		{

		}
	}
}

