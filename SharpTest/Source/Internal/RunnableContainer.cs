using System;
using System.Collections.Generic;

using SharpTest.Reporters;
using SharpTest.Results;

namespace SharpTest.Internal
{
	public class RunnableContainer : List<Runnable>
	{
		public RunnableContainer()
		{
			
		}

		public void Run(Reporter reporter)
		{
			foreach(Runnable runnable in this)
			{
				runnable.Run(reporter);
			}
		}

		public TestSuiteResult CreateTestSuiteResult()
		{
			TestStatus status = TestStatus.Pending;
			uint skipped = 0;
			uint passes = 0;
			long totalTime = 0;
			foreach(Runnable runnable in this)
			{
				totalTime += runnable.Result.TimeTaken;
				//If a single test has been marked as Failed then this 'suite' has failed
				if(runnable.Result.Status == TestStatus.Failed)
				{
					status = TestStatus.Failed;
				} 
				else if(runnable.Result.Status == TestStatus.Skipped)
				{
					skipped++;
				} 
				else
				{
					passes++;
				}
			}

			if(skipped == this.Count)
			{
				status = TestStatus.Skipped;
			}

			if(passes == this.Count)
			{
				status = TestStatus.Passed;
			}

			return new TestSuiteResult(status, totalTime, (uint)this.Count, passes, skipped);
		}

		public TestRunnerResult CreateTestRunnerResult()
		{
			TestStatus status = TestStatus.Failed;
			uint skipped = 0;
			uint passes = 0;
			uint total = 0;
			long totalTime = 0;

			foreach(Runnable runnable in this)
			{
				TestSuiteResult result = (TestSuiteResult)runnable.Result;

				totalTime += runnable.Result.TimeTaken;
				skipped += result.Skipped;
				passes += result.Passes;
				total += result.Total;
			}

			if(skipped == this.Count)
			{
				status = TestStatus.Skipped;
			}

			if(passes == this.Count)
			{
				status = TestStatus.Passed;
			}

			return new TestRunnerResult(status, totalTime, total, passes, skipped);
		}

		public void Prepare()
		{
			//Iterate over each runnable and prepare it ready for testing
			//and mark the 'only' options if required

			Boolean only = false;
			foreach(Runnable runnable in this) 
			{
				runnable.Prepare();
				if(runnable.Format == TestFormat.Only)
				{
					only = true;
				}
			}

			if(only)
			{
				RemoveNonOnly();
			} 

			this.Sort();
		}

		private void RemoveNonOnly()
		{
			for (var i = Count - 1; i >= 0; i--)
			{ 
				Runnable runnable = this[i];
				if(runnable.Format != TestFormat.Only)
				{
					runnable.SetSkipped();
				}
			}
		}

		private void RemoveSkipped()
		{
			for (var i = Count - 1; i >= 0; i--)
			{ 
				Runnable runnable = this[i];
				if(runnable.Format == TestFormat.Skip)
				{
					runnable.SetSkipped();
					this.RemoveAt(i);
				}
			}
		}
	}
}

