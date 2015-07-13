using System;
using System.Reflection;

using SharpTest.Results;
using SharpTest.Internal;

namespace SharpTest
{
	/// <summary>
	/// Test
	/// The front facing Test interface. This allows the developer to recieve the Test through the 
	/// BeforeEach/AfterEach inside of the TestSuite
	/// </summary>
	public sealed class Test : Runnable
	{
		private TestResult result = null;

		private MethodInfo method = null;
		private TestSuite caller = null;
		private Boolean isAsync = false;

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

		internal override void Prepare() 
		{
			ParseReflectiveProperties();
		}

		internal override void ParseReflectiveProperties()
		{
			Name = ParseName(this.method.Name);
		}
	}
}

