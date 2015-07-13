using System;
using System.Reflection;

using SharpTest.Results;
using System.Text;

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

		private TestResult result = null;

		private MethodInfo method = null;
		private TestSuite caller = null;
		private Boolean isAsync = false;

		internal String Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		internal String Description
		{
			get { return this.description; }
			set { this.description = value; }
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

		public TestResult Result
		{
			get { return this.result; }
			internal set { this.result = value; }
		}

		internal Test(MethodInfo method, TestSuite caller)
		{
			this.method = method;
			this.caller = caller;
		}

		private void ParseReflectiveProperties()
		{
			Name = ParseName(method.Name);
		}

		private String ParseName(String name)
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

		internal void Prepare() 
		{
			ParseReflectiveProperties();
		}

		private void ParseTestAttribute() 
		{
			TestAttribute testAttribute = (TestAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(TestAttribute));
			if(testAttribute != null) 
			{
				Name = testAttribute.Name;
				Description = testAttribute.Description;
				Format = testAttribute.Format;
				Order = testAttribute.Order;
			}
		}
	}
}

