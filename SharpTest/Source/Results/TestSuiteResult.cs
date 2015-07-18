using System;

using SharpTest.Internal;

namespace SharpTest.Results
{
	public class TestSuiteResult : Result
	{
		private uint total = 0;
		private uint passes = 0;
		private uint skipped = 0;

		public uint Total
		{
			get { return this.total; }
			internal set { this.total = value; }
		}

		public uint Passes
		{
			get { return this.passes; }
			internal set { this.passes = value; }
		}

		public uint Skipped 
		{
			get { return this.skipped; }
			internal set { this.skipped = value; }
		}

		public uint Failures
		{
			get { return this.total - (this.passes + this.skipped); }
		}

		public TestSuiteResult()
		{

		}

		public TestSuiteResult(TestStatus status)
		{
			Status = status;
		}

		public TestSuiteResult(TestStatus status, long timeTaken, uint total, uint passes, uint skipped)
		{
			Status = status;
			TimeTaken = timeTaken;
			Total = total;
			Passes = passes;
			Skipped = skipped;
		}
	}
}

