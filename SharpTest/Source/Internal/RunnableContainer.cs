using System;
using System.Collections.Generic;

namespace SharpTest.Internal
{
	public class RunnableContainer : List<Runnable>
	{
		public RunnableContainer()
		{
			
		}

		public void Prepare()
		{
			//Iterate over each runnable and prepare it ready for testing
			//and mark the 'only' options if required

			Boolean only = false;
			foreach(Runnable runnable in this) 
			{
				runnable.Prepare();
				if(runnable.Format == TestFormat.Only)
				{
					only = true;
				}
			}

			if(only)
			{
				RemoveNonOnly();
			} 
			else
			{
				RemoveSkipped();
			}

			this.Sort();
		}

		private void RemoveNonOnly()
		{
			for (var i = Count - 1; i >= 0; i--)
			{ 
				Runnable runnable = this[i];
				if(runnable.Format != TestFormat.Only)
				{
					this.RemoveAt(i);
				}
			}
		}

		private void RemoveSkipped()
		{
			for (var i = Count - 1; i >= 0; i--)
			{ 
				Runnable runnable = this[i];
				if(runnable.Format == TestFormat.Skip)
				{
					this.RemoveAt(i);
				}
			}
		}
	}
}

