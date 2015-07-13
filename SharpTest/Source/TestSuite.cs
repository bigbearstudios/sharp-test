using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using SharpTest.Internal;

namespace SharpTest
{
	public class TestSuite : Runnable
	{
		private RunnableContainer tests = new RunnableContainer();

		private RunnableContainer Tests 
		{
			get { return this.tests; }
		}

		public TestSuite()
		{
			
		}

		public virtual void BeforeAll()
		{

		}

		public virtual Task BeforeAllAsync()
		{
			return null;
		}

		public virtual void AfterAll()
		{

		}

		public virtual Task AfterAllAsync()
		{
			return null;
		}

		public virtual void BeforeEach(Test test)
		{

		}

		public virtual Task BeforeEachAsync(Test test)
		{
			return null;
		}

		public virtual void AfterEach(Test test)
		{

		}

		public virtual Task AfterEachAsync(Test test)
		{
			return null;
		}

		internal override void Prepare()
		{
			base.Prepare();
			PrepareTests();
		}
	
		private void PrepareTests()
		{
			//Get all the public methods linked to the test suite
			MethodInfo[] methods = this.GetType().GetMethods();
			foreach(MethodInfo method in methods) 
			{
				if(ShouldRegisterMethod(method)) 
				{
					Tests.Add(new Test(method, this));
				}
			}

			Tests.Prepare();
		}

		private Boolean ShouldRegisterMethod(MethodInfo method)
		{
			HashSet<String> toIgnore = new HashSet<string>{"BeforeAll", "BeforeAllAsync", "AfterAll", "AfterAllAsync", "BeforeEach" , "BeforeEachAsync", "AfterEach", "AfterEachAsync", "CompareTo", "ToString", "GetHashCode", "GetType", "Equals"};
			return !(toIgnore.Contains(method.Name));
		}
	}
}

