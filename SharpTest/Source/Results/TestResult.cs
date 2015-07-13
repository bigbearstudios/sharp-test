using System;

namespace SharpTest.Results
{
	public class TestResult
	{
		private UInt32 timeTaken = 0;
		private TestStatus status = TestStatus.Pending;

		public UInt32 TimeTaken
		{
			get { return this.timeTaken; }
			internal set { this.timeTaken = value; }
		}

		public TestStatus Status
		{
			get { return this.status; }
			internal set { this.status = value; }
		}	

		public TestResult()
		{
			
		}
	}
}

