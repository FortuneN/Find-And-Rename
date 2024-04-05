using FR.CLI;
using NUnit.Framework;

namespace FR.Core.Tests
{
	public class Tests
	{
		[Test]
		public void Zero_Args_Must_Not_Succeed()
		{
			// arrange

			var args = new string[]
			{
			};

			// act

			var result = Program.Main(args);

			// assert

			Assert.AreEqual(1, result);
		}
	}
}