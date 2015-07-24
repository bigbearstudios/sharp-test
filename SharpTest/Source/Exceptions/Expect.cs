using System;
using System.ComponentModel;

using SharpTest.Exceptions.Chains;

namespace SharpTest.Exceptions
{
	public class Expect
	{
		private String name = null;
		private Object testObject = null;
		private Boolean reversed = false;

		internal String Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		internal Object TestObject
		{
			get { return this.testObject; }
			set { this.testObject = value; }
		}

		internal Boolean Reversed
		{
			get { return this.reversed; }
			set { this.reversed = value; }
		}

		public Expect(Object testObject)
		{
			Name = null;
			Reversed = false;
			TestObject = testObject;
		}

		public Expect(Object testObject, String name)
		{
			Name = name;
			Reversed = false;
			TestObject = testObject;
		}

		public To To
		{
			get
			{
				return new To(this);
			}
		}

		public Not Not 
		{
			get
			{
				return new Not(this);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private new int GetHashCode()
		{
			throw new Exception("Expect does not implement GetHashCode");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private new Type GetType()
		{
			throw new Exception("Expect does not implement GetType");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private new string ToString()
		{
			throw new Exception("Expect does not implement ToString");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool Equals(object obj)
		{
			throw new Exception("Expect does not implement Equals");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool ReferenceEquals(object objA, object objB)
		{
			throw new Exception("Expect does not implement ReferenceEquals");
		}
	}
}

