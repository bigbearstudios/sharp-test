using System;
using System.Threading.Tasks;

using SharpTest.Core.Loading;

namespace SharpTest
{
	public class TestRunner
	{
		public TestRunner()
		{
			TestSuiteLoader.Load();
		}

		public virtual void Before() 
		{
			
		}

		public virtual Task BeforeAsync()
		{
			return null;
		}

		public virtual void After()
		{

		}

		public virtual Task AfterAsync()
		{
			return null;
		}

		public static void Start<T>() where T: new()
		{
			T runner = new T();

		}
	}
}

