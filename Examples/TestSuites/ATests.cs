using System;
using System.Collections.Generic;

using SharpTest;
using SharpTest.Exceptions;

namespace Examples
{
	public class ATests : TestSuite
	{
		private int[] emptyArray = new int[]{};
		private int[] filledArray = new int[]{1,2,3,4,5};

		private List<int> emptyList = new List<int>();
		private List<int> filledList = new List<int>(){ 1, 2, 3, 4, 5 };

		public void Length()
		{
			new Expect(emptyArray).To.Have.A.Length.EqualTo(0);
			new Expect(filledArray).To.Have.A.Length.EqualTo(5);
			new Expect(filledArray).To.Have.A.Length.Above(4);
			new Expect(filledArray).To.Have.A.Length.AtLeast(4);
			new Expect(filledArray).To.Have.A.Length.Below(6);
			new Expect(filledArray).To.Have.A.Length.Between(4, 6);
			new Expect(filledArray).To.Have.A.Length.CloseTo(4, 2);
			new Expect(filledArray).To.Have.A.Length.Of(5);
			new Expect(filledArray).To.Have.A.Length.Within(4, 6);
		}

		public void Count()
		{
			new Expect(emptyList).To.Have.A.Count.EqualTo(0);
			new Expect(filledList).To.Have.A.Count.EqualTo(5);
			new Expect(filledList).To.Have.A.Count.Above(4);
			new Expect(filledList).To.Have.A.Count.AtLeast(4);
			new Expect(filledList).To.Have.A.Count.Below(6);
			new Expect(filledList).To.Have.A.Count.Between(4, 6);
			new Expect(filledList).To.Have.A.Count.CloseTo(4, 2);
			new Expect(filledList).To.Have.A.Count.Of(5);
			new Expect(filledList).To.Have.A.Count.Within(4, 6);
		}
	}
}

