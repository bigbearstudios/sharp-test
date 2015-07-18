using System;
using System.Text;

using SharpTest.Tests;

namespace SharpTest.Reporters
{
	public class Reporter
	{
		private ReportBuilder reportBuilder = null;

		internal ReportBuilder ReportBuilder
		{
			get { return this.reportBuilder; }
			set { this.reportBuilder = value; }
		}

		public Reporter()
		{
			ReportBuilder = new ReportBuilder();
		}

		/*
		 * Header Processing
		 */

		internal void CallBuildHeader()
		{
			BuildHeader(ReportBuilder);
		}
	
		public virtual void BuildHeader(ReportBuilder builder)
		{
			builder.AppendLine("#Test Results")
				.AppendLine();
		}

		/*
		 * Test Suite Header (One per TestSuite)
		 */

		internal void CallBuildTestSuiteHeader(TestSuite suite)
		{
			BuildTestSuiteHeader(ReportBuilder, suite);
		}

		public virtual void BuildTestSuiteHeader(ReportBuilder builder, TestSuite suite)
		{
			builder.AppendLine("#" + suite.Name);
		}

		/*
		 * Test (Multiple Per Test Suite)
		 */

		internal void CallBuildTestSuccess(Test test)
		{
			BuildTestSuccess(ReportBuilder, test);
		}

		public virtual void BuildTestSuccess(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t✔ " + test.Name);
		}

		internal void CallBuildTestFailure(Test test)
		{
			BuildTestFailure(ReportBuilder, test);
		}

		public virtual void BuildTestFailure(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t✖ " + test.Name);
		}

		internal void CallBuildTestSkipped(Test test)
		{
			BuildTestSkipped(ReportBuilder, test);
		}

		public virtual void BuildTestSkipped(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t∼ " + test.Name);
		}

		/*
		 * Test Separator (One  after each test)
		 */

		internal void CallBuildTestSeparator()
		{
			BuildTestSeparator(ReportBuilder);
		}

		public virtual void BuildTestSeparator(ReportBuilder builder)
		{

		}

		/*
		 * TestSuite footer (One per test suite)
		 */

		internal void CallBuildTestSuiteFooter(TestSuite suite)
		{
			BuildTestSuiteFooter(ReportBuilder, suite);
		}

		public virtual void BuildTestSuiteFooter(ReportBuilder builder, TestSuite suite)
		{
			
		}

		/*
		 * TestSuite Separator (One after each suite)
		 */

		internal void CallBuildTestSuiteSeperator()
		{
			BuildTestSuiteSeperator(ReportBuilder);
		}

		public virtual void BuildTestSuiteSeperator(ReportBuilder builder)
		{

		}

		/*
		 * Footer (One after all suites)
		 */

		internal void CallBuildFooter(TestRunner runner)
		{
			BuildFooter(ReportBuilder,runner);
		}

		public virtual void BuildFooter(ReportBuilder builder, TestRunner runner)
		{

		}

		internal void CallBuildErrorList()
		{
			BuildErrorList(ReportBuilder);
		}

		public virtual void BuildErrorList(ReportBuilder builder)
		{

		}
	}
}

