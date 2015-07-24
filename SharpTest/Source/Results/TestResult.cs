using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

using SharpTest.Internal;


namespace SharpTest.Results
{
	public class TestFailure 
	{
		uint number = 0;
		Exception exception = null;

		public Exception Exception
		{
			get { return this.exception; }
			internal set { this.exception = value; }
		}

		public uint Number
		{
			get { return this.number; }
			internal set { this.number = value; }
		}

		public TestFailure(Exception exception)
		{
			Exception = exception;
		}

		public String ExceptionMessage
		{
			get { return this.exception.Message; }
		}

		public String ExceptionStackTrace
		{
			get { return SplitStackTrace(this.exception); }
		}

		public String[] ExceptionStackFrames
		{
			get { return SplitStackTraceIntoFrames(this.exception); }
		}

		private String SplitStackTrace(Exception ex)
		{
			String trace = ex.StackTrace.Trim();
			String[] traceSplit = trace.Split(new string[] { "at" }, StringSplitOptions.RemoveEmptyEntries);

			StackTrace stackTrace = new StackTrace(ex, true);

			StringBuilder builder = new StringBuilder();
			for(int i = 0; i < stackTrace.FrameCount - 1; ++i)
			{
				String traceLine = traceSplit[i];
				if(!traceLine.Contains("SharpTest.Exceptions"))
				{
					builder.AppendLine(traceLine);
				}
			}

			return builder.ToString();
		}

		private String[] SplitStackTraceIntoFrames(Exception ex)
		{
			String trace = ex.StackTrace.Trim();
			String[] traceSplit = trace.Split(new string[] { "at" }, StringSplitOptions.RemoveEmptyEntries);

			StackTrace stackTrace = new StackTrace(ex, true);

			List<String> frames = new List<string>();
			for(int i = 0; i < stackTrace.FrameCount - 1; ++i)
			{
				String traceLine = traceSplit[i];
				if(!traceLine.Contains("SharpTest.Exceptions"))
				{
					frames.Add(traceLine);
				}
			}

			return frames.ToArray();
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
			Failure = new TestFailure(exception);
		}
			
		public TestResult(TestStatus status, long timeTaken, long memoryUsage)
		{
			Status = status;
			TimeTaken = timeTaken;
			MemoryUsage = memoryUsage;
		}
	}
}

