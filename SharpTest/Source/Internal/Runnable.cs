using System;
using System.Text;

namespace SharpTest.Internal
{
	public class Runnable : IComparable<Runnable>
	{
		private String name = null;
		private String description = null;
		private TestFormat format = TestFormat.Run;
		private UInt32 order = 0;

		public String Name
		{
			get { return this.name; }
			internal set { this.name = value; }
		}

		public String Description
		{
			get { return this.description; }
			internal set { this.description = value; }
		}

		internal TestFormat Format
		{
			get { return this.format; }
			set { this.format = value; }
		}

		internal UInt32 Order
		{
			get { return this.order; }
			set { this.order = value; }
		}

		public Runnable()
		{
			
		}

		public int CompareTo(Runnable runnable)
		{
			return this.Order.CompareTo(runnable.Order);
		}

		internal virtual void Prepare()
		{
			ParseReflectiveProperties();
			ParseTestSuiteAttribute();
		}

		internal virtual void ParseReflectiveProperties()
		{
			Name = this.GetType().Name;
		}

		internal void ParseTestSuiteAttribute() 
		{
			TestAttribute testAttribute = (TestAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(TestAttribute));
			if(testAttribute != null) 
			{
				if(testAttribute.Name != null)
				{
					Name = testAttribute.Name;
				}

				Description = testAttribute.Description;
				Format = testAttribute.Format;
				Order = testAttribute.Order;
			}
		}

		internal String ParseName(String name)
		{
			StringBuilder builder = new StringBuilder();
			foreach (char c in name) {
				if(Char.IsUpper(c) && builder.Length > 0) 
				{
					builder.Append(' ');
				}

				builder.Append(c);
			}

			return builder.ToString();
		}
	}
}

