using System;

namespace SharpTest.Results
{
	public enum TestStatus
	{
		/// <summary>
		/// Pending
		/// The Test is waiting to be ran
		/// </summary>
		Pending = 0,

		/// <summary>
		/// Running
		/// The test is current running
		/// </summary>
		Running = 1,

		/// <summary>
		/// Skipped
		/// The test got completely skipped
		/// </summary>
		Skipped = 2,

		/// <summary>
		/// Passed
		/// The test passed
		/// </summary>
		Passed = 3,

		/// <summary>
		/// Failed
		/// The test failed
		/// </summary>
		Failed = 4
	}
}

