using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using SharpTest.Tests;
using SharpTest.Results;
using SharpTest.Internal;
using SharpTest.Reporters;

namespace SharpTest
{
	public class TestSuite : Runnable
	{
		private RunnableContainer tests = new RunnableContainer();

		private RunnableContainer Tests 
		{
			get { return this.tests; }
		}

		public new TestSuiteResult Result
		{
			get { return (TestSuiteResult)this.result; }
			internal set { this.result = (TestSuiteResult)value; }
		}

		internal override Result TestResult()
		{
			return Result;
		}

		public TestSuite()
		{
			
		}

		public virtual void BeforeAll()
		{

		}

		public virtual Task BeforeAllAsync()
		{
			return null;
		}

		public virtual void AfterAll()
		{

		}

		public virtual Task AfterAllAsync()
		{
			return null;
		}

		public virtual void BeforeEach(Test test)
		{

		}

		public virtual Task BeforeEachAsync(Test test)
		{
			return null;
		}

		public virtual void AfterEach(Test test)
		{

		}

		public virtual Task AfterEachAsync(Test test)
		{
			return null;
		}

		internal override void SetSkipped()
		{
			Format = TestFormat.Skip;
			Result = new TestSuiteResult(TestStatus.Skipped);
		}

		internal override void Run(Reporter reporter)
		{
			if(Format != TestFormat.Skip)
			{
				reporter.CallBuildTestSuiteHeader(this);
				Tests.Run(reporter);
				Result = Tests.CreateTestSuiteResult();
				reporter.CallBuildTestSuiteFooter(this);
			} 
			else
			{
				Result = new TestSuiteResult(TestStatus.Skipped);
			}
		}

		internal override void Prepare()
		{
			base.Prepare();
			PrepareTests();
		}

		internal override void ParseReflectiveProperties()
		{
			Name = this.GetType().Name;
		}
	
		private void PrepareTests()
		{
			//Get all the public methods linked to the test suite
			MethodInfo[] methods = this.GetType().GetMethods();
			foreach(MethodInfo method in methods) 
			{
				if(ShouldRegisterMethod(method)) 
				{
					Tests.Add(new Test(method, this));
				}
			}

			Tests.Prepare();
		}

		private Boolean ShouldRegisterMethod(MethodInfo method)
		{
			if(method.IsSpecialName)
			{
				return false;
			}

			HashSet<String> toIgnore = new HashSet<string>{"BeforeAll", "BeforeAllAsync", "AfterAll", "AfterAllAsync", "BeforeEach" , "BeforeEachAsync", "AfterEach", "AfterEachAsync", "CompareTo", "ToString", "GetHashCode", "GetType", "Equals"};
			return !(toIgnore.Contains(method.Name));
		}
	}
}

