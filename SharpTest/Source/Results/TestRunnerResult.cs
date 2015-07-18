using System;

using SharpTest.Internal;

namespace SharpTest.Results
{
	public class TestRunnerResult : TestSuiteResult
	{
		public TestRunnerResult(TestStatus status, long timeTaken, uint total, uint passes, uint skipped)
		{
			Status = status;
			TimeTaken = timeTaken;
			Total = total;
			Passes = passes;
			Skipped = skipped;
		}
	}
}

