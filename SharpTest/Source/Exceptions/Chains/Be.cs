﻿using System;

using SharpTest.Exceptions.Checks;

namespace SharpTest.Exceptions.Chains
{
	public class Be : Chain
	{
		public Be(Expect expect) : base(expect)
		{
			
		}

		/*
		 * Chains
		 */

		public An An
		{
			get
			{
				return new An(Expect);
			}
		}

		/*
		 * Checks
		 */

		public void A(Type type)
		{
			Checks.InstanceOf.Check(Expect, type);
		}

		public void EqualTo(object toEqual)
		{
			Checks.EqualTo.Check(Expect, toEqual);
		}

		public void Ok()
		{
			Checks.Ok.Check(Expect);
		}

		public void True()
		{
			Checks.Ok.Check(Expect);
		}

		public void False()
		{
			Expect.Reversed = !Expect.Reversed;
			Checks.Ok.Check(Expect);
		}

		public void Null()
		{
			Checks.Null.Check(Expect);
		}

		/*
		 * Number Checks
		 */

		public void AtLeast(int atleast)
		{
			Checks.AtLeast.Check(Expect, atleast);
		}

		public void AtLeast(float atleast)
		{
			Checks.AtLeast.Check(Expect, atleast);
		}

		public void AtLeast(double atleast)
		{
			Checks.AtLeast.Check(Expect, atleast);
		}

		public void Above(int above)
		{
			Checks.Above.Check(Expect, above);
		}

		public void Above(float above)
		{
			Checks.Above.Check(Expect, above);
		}

		public void Above(double above)
		{
			Checks.Above.Check(Expect, above);
		}
			
		public void Below(int below)
		{
			Checks.Below.Check(Expect, below);
		}

		public void Below(float below)
		{
			Checks.Below.Check(Expect, below);
		}

		public void Below(double below)
		{
			Checks.Below.Check(Expect, below);
		}
			
		public void Within(int lower, int higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}

		public void Within(float lower, float higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}

		public void Within(double lower, double higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}

		public void Between(int lower, int higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}

		public void Between(float lower, float higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}

		public void Between(double lower, double higher)
		{
			Checks.Within.Check(Expect, lower, higher);
		}
			
		public void CloseTo(int closeTo, int delta)
		{
			Checks.CloseTo.Check(Expect, closeTo, delta);
		}

		public void CloseTo(float closeTo, float delta)
		{
			Checks.CloseTo.Check(Expect, closeTo, delta);
		}

		public void CloseTo(double closeTo, double delta)
		{
			Checks.CloseTo.Check(Expect, closeTo, delta);
		}
	}
}