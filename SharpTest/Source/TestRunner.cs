using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using SharpTest.Internal;
using SharpTest.Reporters;
using SharpTest.Results;

namespace SharpTest
{
	public class TestRunner
	{
		private Reporter reporter = null;
		private TestRunnerResult result = null;
		private RunnableContainer testSuites = null;

		internal Reporter Reporter
		{
			get { return this.reporter; }
			set { this.reporter = value; }
		}

		public TestRunnerResult Result
		{
			get { return this.result; }
			internal set { this.result = value; }
		}

		internal RunnableContainer TestSuites
		{
			get { return this.testSuites; }
			set { this.testSuites = value; }
		}

		public TestRunner()
		{
			TestSuites = TestSuiteLoader.Load();
			TestSuites.Prepare();
		}

		public void Start()
		{
			LoadReporter();

			Before();

			Task beforeTask = BeforeAsync();
			if(beforeTask != null) 
			{
				beforeTask.Wait();
			}

			Run();
			After();

			Task afterTask = AfterAsync();
			if(afterTask != null) 
			{
				afterTask.Wait();
			}
		}

		private void LoadReporter()
		{
			Reporter = new Reporter();
		}

		public virtual void Before() 
		{

		}

		public virtual Task BeforeAsync()
		{
			return null;
		}

		private void Run()
		{
			Reporter.CallBuildHeader();
			TestSuites.Run(Reporter);
			Result = TestSuites.CreateTestRunnerResult();
			Reporter.CallBuildFooter(this);
		}

		public virtual void After()
		{

		}

		public virtual Task AfterAsync()
		{
			return null;
		}

		public static void Start<T>() where T: TestRunner,  new()
		{
			T runner = new T();
			runner.Start();
		}
	}
}

