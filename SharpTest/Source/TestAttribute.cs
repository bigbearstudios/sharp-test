using System;

namespace SharpTest
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class TestAttribute : Attribute
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

		public TestAttribute()
		{
			
		}

		public TestAttribute(String name = null)
		{
			Name = name;
		}

		public TestAttribute(String name = null, UInt32 order = 0)
		{
			Name = name;
			Order = order;
		}

		public TestAttribute(TestFormat format = TestFormat.Run)
		{
			Format = format;
		}

		public TestAttribute(UInt32 order = 0)
		{	
			Order = order;
		}

		public TestAttribute(UInt32 order = 0, TestFormat format = TestFormat.Run)
		{
			Order = order;
			Format = format;
		}
			
		public TestAttribute(String name = null, TestFormat format = TestFormat.Run)
		{
			Name = name;
			Format = format;
		}

		public TestAttribute(String name = null, String description = null) 
		{
			Name = name;
			Description = description;
		}

		public TestAttribute(String name = null, String description = null, UInt32 order = 0)
		{
			Name = name;
			Description = description;
			Order = order;
		}

		public TestAttribute(String name = null, String desciption = null, TestFormat format = TestFormat.Run)
		{
			Name = name;
			Description = description;
			Format = format;
		} 

		public TestAttribute(String name = null, String desciption = null, UInt32 order = 0, TestFormat format = TestFormat.Run)
		{
			Name = name;
			Description = description;
			Order = order;
			Format = format;
		}
	}
}

