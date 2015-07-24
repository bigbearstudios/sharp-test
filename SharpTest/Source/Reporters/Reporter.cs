using System;
using System.Text;
using System.Collections.Generic;

using SharpTest.Tests;

namespace SharpTest.Reporters
{
	public abstract class Reporter
	{
		private ReportBuilder reportBuilder = null;

		private List<Test> failures = new List<Test>();

		internal ReportBuilder ReportBuilder
		{
			get { return this.reportBuilder; }
			set { this.reportBuilder = value; }
		}

		private List<Test> Failures
		{
			get { return this.failures; }
		}

		public Reporter()
		{
			ReportBuilder = new ReportBuilder();
		}

		public virtual void BuildHeader(ReportBuilder builder) { }
		public virtual void BuildTestSuiteHeader(ReportBuilder builder, TestSuite suite){}
		public virtual void BuildTestSuccess(ReportBuilder builder, Test test) {}
		public virtual void BuildTestFailure(ReportBuilder builder, Test test) {}
		public virtual void BuildTestSkipped(ReportBuilder builder, Test test) {}
		public virtual void BuildTestSeparator(ReportBuilder builder) { }
		public virtual void BuildTestSuiteFooter(ReportBuilder builder, TestSuite suite) { }
		public virtual void BuildTestSuiteSeperator(ReportBuilder builder) { }
		public virtual void BuildFooter(ReportBuilder builder, TestRunner runner) { }
		public virtual void BuildErrorListHeader(ReportBuilder builder, TestRunner runner) { }
		public virtual void BuildErrorList(ReportBuilder builder, Test test) {}
		public virtual void BuildErrorListFooter(ReportBuilder builder, TestRunner runner) { }

		internal void CallBuildHeader(TestRunner runner)
		{
			BuildHeader(ReportBuilder);
		}

		internal void CallBuildTestSuiteHeader(TestSuite suite)
		{
			BuildTestSuiteHeader(ReportBuilder, suite);
		}
	
		internal void CallBuildTestSuccess(Test test)
		{
			BuildTestSuccess(ReportBuilder, test);
		}

		internal void CallBuildTestFailure(Test test)
		{
			IncrementFailureNumber(test);
			BuildTestFailure(ReportBuilder, test);
		}

		private void IncrementFailureNumber(Test test)
		{
			Failures.Add(test);
			test.Result.Failure.Number = (uint)Failures.Count;
		}
			
		internal void CallBuildTestSkipped(Test test)
		{
			BuildTestSkipped(ReportBuilder, test);
		}
			
		internal void CallBuildTestSeparator()
		{
			BuildTestSeparator(ReportBuilder);
		}
			
		internal void CallBuildTestSuiteFooter(TestSuite suite)
		{
			BuildTestSuiteFooter(ReportBuilder, suite);
		}
			
		internal void CallBuildTestSuiteSeperator()
		{
			BuildTestSuiteSeperator(ReportBuilder);
		}
			
		internal void CallBuildFooter(TestRunner runner)
		{
			BuildFooter(ReportBuilder, runner);
		}
			
		internal void CallBuildFailureList(TestRunner runner)
		{
			if(Failures.Count > 0)
			{
				BuildErrorListHeader(ReportBuilder, runner);

				foreach(Test failedTest in Failures)
				{
					BuildErrorList(ReportBuilder, failedTest);
				}

				BuildErrorListFooter(ReportBuilder, runner);
			}
		}
	}
}

