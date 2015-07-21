﻿using System;

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

