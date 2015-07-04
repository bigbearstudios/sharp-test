using System;
using System.Reflection;
using System.Collections.Generic;

namespace SharpTest.Core.Loading
{
	public class TestSuiteLoader
	{
		private HashSet<String> ignoredAssemblies = new HashSet<string>();
		private List<TestSuite> testSuites = new List<TestSuite>();

		public TestSuiteLoader()
		{
			registerIgnoredAssemblies();
		}

		private void registerIgnoredAssemblies()
		{
			ignoredAssemblies.Add("mscorlib");
		}
			
		private List<TestSuite> LoadTestSuites()
		{
			_LoadSuitesFromAssembly(Assembly.GetEntryAssembly(), 0);
			return testSuites;
		}

		private void _LoadSuitesFromAssembly(Assembly assembly, Int32 level) 
		{
			if(IgnoreAssembly(assembly)){ return; }
			if(level == 3){ return; }	

			/*
			 * Check the types which are contained inside of the assembly for any TestSuite
			 * linkages
			 */
			Type[] types = assembly.GetTypes();
			foreach(Type type in types)
			{
				if(type.IsSubclassOf(typeof(TestSuite)))
				{
					ConstructorInfo constructor = type.GetConstructor(new Type[]{});
					if(constructor != null)
					{
						TestSuite testSuite = (TestSuite)constructor.Invoke(new object[]{});
						testSuites.Add(testSuite);
					}
				}
			}

			/*
			 * Move onto the referenceAssemblies of the current Assemblie and continue loading them
			 */
			AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
			foreach(AssemblyName assemblyName in referencedAssemblies)
			{
				Assembly referencedAssembly = Assembly.Load(assemblyName);
				_LoadSuitesFromAssembly(referencedAssembly, ++level);
			}
		}

		private bool IgnoreAssembly(Assembly assembly)
		{
			String assemblyName = assembly.GetName().Name;
			return !(ignoredAssemblies.Contains(assemblyName));
		}

		public static List<TestSuite> Load()
		{
			TestSuiteLoader loader = new TestSuiteLoader();
			return loader.LoadTestSuites();
		}
	}
}

