using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using SharpTest.Loading;
using SharpTest.Internal;

namespace SharpTest
{
	public class TestRunner
	{
		RunnableContainer testSuites = null;

		private RunnableContainer TestSuites
		{
			get { return this.testSuites; }
			set { this.testSuites = value; }
		}

		public TestRunner()
		{
			TestSuites = TestSuiteLoader.Load();
			TestSuites.Prepare();
		}

		public void Start()
		{
			Before();

			Task beforeTask = BeforeAsync();
			if(beforeTask != null) 
			{
				beforeTask.Wait();
			}

			Run();
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

		private void Run()
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

