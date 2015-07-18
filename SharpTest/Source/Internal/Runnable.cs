using System;
using System.Text;

using SharpTest.Reporters;
using SharpTest.Results;

namespace SharpTest.Internal
{
	public abstract class Runnable : IComparable<Runnable>
	{
		private String name = null;
		private String description = null;
		private TestFormat format = TestFormat.Run;
		private UInt32 order = 100;

		protected Result result;

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

		internal Result Result
		{
			get { return this.result; }
			set { this.result = value; }
		}

		public int CompareTo(Runnable runnable)
		{
			return this.Order.CompareTo(runnable.Order);
		}

		internal abstract void Run(Reporter reporter);
		internal abstract void SetSkipped();
		internal abstract Result TestResult();
		internal abstract void ParseReflectiveProperties();

		internal virtual void Prepare()
		{
			ParseReflectiveProperties();
			ParseTestSuiteAttribute();
		}

		internal void ParseTestSuiteAttribute() 
		{
			TestAttribute testAttribute = FindTestAttribute();
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

		internal virtual TestAttribute FindTestAttribute()
		{
			return (TestAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(TestAttribute));
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

