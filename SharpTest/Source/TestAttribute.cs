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

		public TestAttribute(String name)
		{
			Name = name;

		}

		public TestAttribute(String name, UInt32 order)
		{
			Name = name;
			Order = order;
		}

		public TestAttribute(TestFormat format)
		{
			Format = format;
		}

		public TestAttribute(UInt32 order)
		{	
			Order = order;
		}

		public TestAttribute(UInt32 order, TestFormat format)
		{
			Order = order;
			Format = format;
		}
			
		public TestAttribute(String name, TestFormat format)
		{
			Name = name;
			Format = format;
		}

		public TestAttribute(String name, String description) 
		{
			Name = name;
			Description = description;
		}

		public TestAttribute(String name, String description, UInt32 order)
		{
			Name = name;
			Description = description;
			Order = order;
		}

		public TestAttribute(String name, String desciption, TestFormat format)
		{
			Name = name;
			Description = description;
			Format = format;
		} 

		public TestAttribute(String name, String desciption, UInt32 order, TestFormat format)
		{
			Name = name;
			Description = description;
			Order = order;
			Format = format;
		}
	}
}

