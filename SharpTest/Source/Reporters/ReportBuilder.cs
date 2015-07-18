using System;
using System.Text;

namespace SharpTest.Reporters
{
	public class ReportBuilder
	{
		private StringBuilder stringBuilder = null;

		internal StringBuilder StringBuilder
		{
			get { return this.stringBuilder; }
			set { this.stringBuilder = value; }
		}

		public ReportBuilder()
		{
			
		}

		public ReportBuilder Append(String value, ConsoleColor colour = ConsoleColor.Black)
		{
			if(StringBuilder != null)
			{
				stringBuilder.Append(value);
			}

			Console.ForegroundColor = colour;
			Console.Write(value);

			return this;
		}

		public ReportBuilder AppendLine()
		{
			if(StringBuilder != null)
			{
				stringBuilder.AppendLine();
			}
				
			Console.WriteLine();

			return this;
		}

		public ReportBuilder AppendLine(String value, ConsoleColor colour = ConsoleColor.Black)
		{
			if(StringBuilder != null)
			{
				stringBuilder.AppendLine(value);
			}

			Console.ForegroundColor = colour;
			Console.WriteLine(value);

			return this;
		}
	}
}

