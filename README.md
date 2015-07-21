# Sharp Test

## Overview

Sharp Test is a test runner for C# applications.

### Installation

#### Github

TODO 
Fill in the details about cloning the github repo

#### NuGet

TODO 
Fill in the details about using NuGet

### Features

TODO
Fill in the core features list...

## Tutorials

### TestRunner

The TestRunner itself is the class which starts up the testing process. 

#### Creating a TestRunner

To create a test runner you simply need to inherit the TestRunner class in your 'program.cs' and instantiate your inherited classes in the static Main functions and then call 'Start' on the instantiated class.

There is two ways you can instantiate the runner. The first is using standard instantiation:

	using SharpTest;
	using SharpTest.Runners;

	public class Program : Runner
	{
		public static void Main(string[] args)
		{
			Program myRunner = new Program();
			myRunner.Start();
		}
	}
	
Then second way is using a generic static method which allows you to send in the type of your created class: 

	using SharpTest;
	using SharpTest.Runners;

	public class Program : Runner
	{
		public static void Main(string[] args)
		{
			Runner.Start<Program>();
		}
	}
	
#### Setup/Teardown

Inside of your inherited TestRunner class you will notice there is a couple of functions which are mapped as 'virtual' these allow you to setup anything which might be required before all of the tests are run. 

	using SharpTest;

	public class Program : Runner
	{
		public override void Before()
		{

		}
		
		public override void After()
		{

		}
	}
	
There is also async versions of the Before/After functionality which can be used if you prefur: 

	using SharpTest;

	public class Program : Runner
	{
		public override Task BeforeAsync ()
		{
			//Do some Async stuff
			return new Task(() => {});
		}

		public override Task AfterAsync ()
		{
			//Do some Async stuff
			return new Task(() => {});
		}
	}
	
##### Notes
Its important to note that you can use both the Before, BeforeAsync, After and AfterSync all at the same time and they will be called in the following order: 

* Before
* BeforeAsync
* After
* AfterAsync


### TestSuites

TestSuites are the bread and butter of Sharp Test and allow the user to organise their tests into workable units which will appear as groups when reported.

#### Creating a TestSuite

	using SharpTest;

	public class MyTestSuite : TestSuite
	{
		//The default constructor will always be called if required
		public MyTestSuite ()
		{

		}
	}

#### Setup/Teardown

You are given six functions to aid with the setup/tear down of 

	using SharpTest;

	public class MyTestSuite : TestSuite
	{
		public override void BeforeAll ()
		{

		}

		public override void AfterAll ()
		{

		}

		public override void AfterEach (Test test)
		{

		}

		public override void BeforeEach (Test test)
		{

		}
	}















