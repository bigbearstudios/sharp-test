using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SharpTest
{
	public class TestSuite : IComparable<TestSuite>
	{
		private String name = null;
		private String description = null;
		private TestFormat format = TestFormat.Run;
		private UInt32 order = 0;

		private List<Test> tests = new List<Test>();

		internal String Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		internal String Description
		{
			get { return this.description; }
			set { this.description = value; }
		}

		internal TestFormat Format
		{
			get { return this.format; }
			set { this.format = value; }
		}
			
		internal UInt32 Order
		{
			get { return this.order; }
			set { this.order = value; }
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

		public int CompareTo(TestSuite suite)
		{
			return 0;
		}

		internal void Prepare()
		{
			ParseReflectiveProperties();
			ParseTestSuiteAttribute();
			PrepareTests();

		}

		private void ParseTestSuiteAttribute() 
		{
			TestAttribute testAttribute = (TestAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(TestAttribute));
			if(testAttribute != null) 
			{
				Name = testAttribute.Name;
				Description = testAttribute.Description;
				Format = testAttribute.Format;
				Order = testAttribute.Order;
			}
		}

		private void ParseReflectiveProperties()
		{
			Name = this.GetType().Name;
		}

		private void PrepareTests()
		{
			//Get all the public methods linked to the test suite
			MethodInfo[] methods = this.GetType().GetMethods();
			foreach(MethodInfo method in methods) 
			{
				if(ShouldPrepareMethod(method)) 
				{
					tests.Add(PrepareTest(method));
				}
			}
		}

		private Boolean ShouldPrepareMethod(MethodInfo method)
		{
			HashSet<String> toIgnore = new HashSet<string>{"BeforeAll", "BeforeAllAsync", "AfterAll", "AfterAllAsync", "BeforeEach" , "BeforeEachAsync", "AfterEach", "AfterEachAsync", "CompareTo", "ToString", "GetHashCode", "GetType", "Equals"};
			return !(toIgnore.Contains(method.Name));
		}

		private Test PrepareTest(MethodInfo method)
		{
			Test test = new Test(method, this);
			test.Prepare();
			return test;
		}
	}
}

