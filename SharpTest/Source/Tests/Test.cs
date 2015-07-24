using System;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;

using SharpTest.Internal;
using SharpTest.Reporters;
using SharpTest.Results;

namespace SharpTest.Tests
{
	/// <summary>
	/// Test
	/// The front facing Test interface. This allows the developer to recieve the Test through the 
	/// BeforeEach/AfterEach inside of the TestSuite
	/// </summary>
	public sealed class Test : Runnable
	{
		private MethodInfo method = null;
		private TestSuite caller = null;
		private Boolean isAsync = false;

		private TestSuite Caller
		{
			get { return this.caller; }
			set { this.caller = value; }
		}

		private MethodInfo Method
		{
			get { return this.method; }
			set { this.method = value; }
		}

		private Boolean IsAsync
		{
			get { return this.isAsync; }
			set { this.isAsync = value; }
		}

		internal override Result TestResult()
		{
			return Result;
		}
			
		public new TestResult Result
		{
			get { return (TestResult)this.result; }
			internal set { this.result = (TestResult)value; }
		}

		internal Test(MethodInfo method, TestSuite caller)
		{
			Method = method;
			Caller = caller;
		}

		internal override void SetSkipped()
		{
			Format = TestFormat.Skip;
			Result = new TestResult(TestStatus.Skipped);
		}
			
		internal override void Run(Reporter reporter)
		{
			if(Format != TestFormat.Skip)
			{
				try
				{
					long beforeMemory = GC.GetTotalMemory(true);
					StopWatch.Restart();
		
					RunMethod();

					long elapsedTime = StopWatch.ElapsedMilliseconds;
					long totalMemory = beforeMemory - GC.GetTotalMemory(true);
					StopWatch.Stop();

					Result = new TestResult(TestStatus.Passed, elapsedTime, totalMemory);
					reporter.CallBuildTestSuccess(this);
				} 
				catch(Exception ex)
				{
					Result = new TestResult(ex);
					reporter.CallBuildTestFailure(this);
				}
			} 
			else
			{
				Result = new TestResult(TestStatus.Skipped);
				reporter.CallBuildTestSkipped(this);
			}
		}

		private void RunMethod()
		{
			try
			{
				if(isAsync)
				{
					try 
					{
						Task task = (Task)Method.Invoke(Caller, new object[]{ });
						if(task != null)
						{
							task.Wait();
						}
					}
					catch(InvalidCastException ex)
					{
						Result = new TestResult(ex);
					}
				} 
				else
				{
					Method.Invoke(Caller, new object[]{ });
				}
			}
			catch(TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		internal override void Prepare() 
		{
			base.Prepare();
			ParseReflectiveProperties();
		}

		internal override void ParseReflectiveProperties()
		{
			Name = ParseName(this.method.Name);
		}

		internal override TestAttribute FindTestAttribute()
		{
			return (TestAttribute)Method.GetCustomAttribute(typeof(TestAttribute));
		}

		private void PrepareMethod() 
		{
			Type returnType = Method.ReturnType;
			if(returnType.Equals(typeof(Task)))
			{
				IsAsync = true;
			} 
		}

		/*
		 * Static Functionality
		 */

		static Stopwatch StopWatch = null;

		static Test() 
		{
			StopWatch = new Stopwatch();
		}
	}
}

