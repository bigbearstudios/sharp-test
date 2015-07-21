using System;

using SharpTest.Tests;

namespace SharpTest.Reporters
{
	public class DefaultReporter : Reporter
	{
		public DefaultReporter()
		{
			
		}

		public override void BuildHeader(ReportBuilder builder)
		{
			builder.AppendLine("#Test Results")
				.AppendLine();
		}

		public override void BuildTestSuiteHeader(ReportBuilder builder, TestSuite suite)
		{
			builder.AppendLine("#" + suite.Name);
		}

		public override void BuildTestSuccess(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t✔ " + test.Name);
		}

		public override void BuildTestFailure(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t✖ " + test.Name);
		}

		public override void BuildTestSkipped(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t∼ " + test.Name);
		}
	}
}

