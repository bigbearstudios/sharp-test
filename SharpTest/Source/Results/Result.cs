using System;

namespace SharpTest.Results
{
	public class Result
	{
		protected long timeTaken = 0;
		protected TestStatus status = TestStatus.Pending;

		public long TimeTaken
		{
			get { return this.timeTaken; }
			internal set { this.timeTaken = value; }
		}

		public TestStatus Status
		{
			get { return this.status; }
			internal set { this.status = value; }
		}	

		public Result()
		{

		}

		public Result(TestStatus status)
		{
			Status = status;
		}

		public Result(TestStatus status, long timeTaken)
		{
			Status = status;
			TimeTaken = timeTaken;
		}
	}
}

