using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using SharpTest.Loading;

namespace SharpTest
{
	public class TestRunner
	{
		List<TestSuite> testSuites = null;

		public TestRunner()
		{
			testSuites = TestSuiteLoader.Load();
		}

		public void PrepareTestSuites()
		{
			testSuites.Sort();
			foreach(TestSuite suite in testSuites) 
			{
				suite.Prepare();
			}
		}

		public void Start()
		{
			PrepareTestSuites();

			Before();

			Task beforeTask = BeforeAsync();
			if(beforeTask != null) 
			{
				beforeTask.Wait();
			}

			RunTestSuites();

			After();

			Task afterTask = AfterAsync();
			if(afterTask != null) 
			{
				afterTask.Wait();
			}
		}

		public virtual void Before() 
		{

		}

		public virtual Task BeforeAsync()
		{
			return null;
		}

		private void RunTestSuites()
		{

		}

		public virtual void After()
		{

		}

		public virtual Task AfterAsync()
		{
			return null;
		}

		public static void Start<T>() where T: TestRunner,  new()
		{
			T runner = new T();
			runner.Start();
		}
	}
}

