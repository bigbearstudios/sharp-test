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
			builder.AppendLine("##Test Results")
				.AppendLine();
		}

		public override void BuildTestSuiteHeader(ReportBuilder builder, TestSuite suite)
		{
			builder.AppendLine("#" + suite.Name);
		}

		public override void BuildTestSuccess(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t✔ " + test.Name + "(" + test.Result.TimeTaken + "ms)");
		}

		public override void BuildTestFailure(ReportBuilder builder, Test test)
		{
			builder.AppendLine(String.Format("\t✖ ({0}) {1}",test.Result.Failure.Number, test.Name));
		}

		public override void BuildTestSkipped(ReportBuilder builder, Test test)
		{
			builder.AppendLine("\t∼ " + test.Name);
		}

		public override void BuildErrorListHeader(ReportBuilder builder, TestRunner runner)
		{
			builder.AppendLine("##Failed Test Reasons")
				.AppendLine();
		}

		public override void BuildErrorList(ReportBuilder builder, Test test)
		{
			builder.AppendLine(String.Format("\t({0}) {1}",test.Result.Failure.Number, test.Name));
			builder.AppendLine("\t #Reason");
			builder.AppendLine("\t\t" + test.Result.Failure.ExceptionMessage);
			builder.AppendLine();
			builder.AppendLine("\t #StackTrace");
			foreach(String trace in test.Result.Failure.ExceptionStackFrames)
			{
				builder.AppendLine("\t\t" + trace);
			}
		}
	}
}

