using System;

using SharpTest.Internal;

namespace SharpTest.Results
{
	public class TestFailure 
	{
		Exception exception = null;

		public Exception Exception
		{
			get { return this.exception; }
			internal set { this.exception = value; }
		}

		public TestFailure(Exception exception)
		{
			
		}
	}

	public class TestResult : Result
	{
		private long memoryUsage = 0;

		private TestFailure failure = null;

		public long MemoryUsage
		{
			get { return this.memoryUsage; }
			internal set { this.memoryUsage = value; }
		}

		public TestFailure Failure 
		{
			get { return this.failure; }
			internal set { this.failure = value; }
		}

		public TestResult(TestStatus status)
		{
			Status = status;
		}

		public TestResult(Exception exception)
		{
			Status = TestStatus.Failed;

		}
			
		public TestResult(TestStatus status, long timeTaken, long memoryUsage)
		{
			Status = status;
			TimeTaken = timeTaken;
			MemoryUsage = memoryUsage;
		}
	}
}

