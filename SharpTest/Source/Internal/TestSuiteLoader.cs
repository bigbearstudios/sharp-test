﻿using System;
using System.Reflection;
using System.Collections.Generic;

namespace SharpTest.Internal
{
	internal class TestSuiteLoader
	{
		private HashSet<String> ignoredAssemblies = new HashSet<string>();

		internal TestSuiteLoader()
		{
			registerIgnoredAssemblies();
		}

		private void registerIgnoredAssemblies()
		{
			ignoredAssemblies.Add("mscorlib");
		}
			
		private RunnableContainer LoadTestSuites()
		{
			RunnableContainer testSuites = new RunnableContainer();
			_LoadSuitesFromAssembly(Assembly.GetEntryAssembly(), 0, testSuites);
			return testSuites;
		}
			
		private void _LoadSuitesFromAssembly(Assembly assembly, Int32 level, RunnableContainer testSuites) 
		{
			if(ShouldProcessAssembly(assembly) && (level < 3)) 
			{
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
					_LoadSuitesFromAssembly(referencedAssembly, ++level, testSuites);
				}
			}
		}

		private Boolean ShouldProcessAssembly(Assembly assembly)
		{
			String assemblyName = assembly.GetName().Name;
			return !(ignoredAssemblies.Contains(assemblyName));
		}

		internal static RunnableContainer Load()
		{
			TestSuiteLoader loader = new TestSuiteLoader();
			return loader.LoadTestSuites();
		}
	}
}

