using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C2C;
using System.Collections.Generic;

namespace C2CTests
{
	[TestClass]
	public class Test_DistanceWithQWERTY
	{
		private Distance dist = new Distance();
		private Dictionary<char, Tuple<int, int>> keys;

		[TestInitialize]
		public void Init()
		{
			keys = dist.InitiateQWERTYDict();

		}

		[TestMethod]
		public void TestQToADistance()
		{
			double cost = dist.InputToMatchCost(keys, "Q", "A");
			Assert.AreEqual(1, cost);
		}

		[TestMethod]
		public void TestMulToMilk()
		{
			double cost = dist.InputToMatchCost(keys, "Mulk", "Milk");

			Assert.AreEqual(1, cost);
		}
		[TestMethod]
		public void TestDampToDamn()
		{
			double cost = dist.InputToMatchCost(keys, "Damp", "Damn");

			Assert.AreEqual(4.47, cost);
		}

		[TestMethod]
		public void TestNullStrings()
		{
			double cost = dist.InputToMatchCost(keys, null, null);

			Assert.AreEqual(10000, cost);
			cost = dist.InputToMatchCost(keys, null, "ASDF");

			Assert.AreEqual(10000, cost);
			cost = dist.InputToMatchCost(keys, "ASDF", null);

			Assert.AreEqual(10000, cost);
		}

		[TestMethod]
		public void CheckDictionary()
		{
			Assert.AreEqual(keys['q'], new Tuple<int, int>(0, 0));
			Assert.AreEqual(keys['w'], new Tuple<int, int>(0, 1));
			Assert.AreEqual(keys['e'], new Tuple<int, int>(0, 2));
			Assert.AreEqual(keys['r'], new Tuple<int, int>(0, 3));
			Assert.AreEqual(keys['t'], new Tuple<int, int>(0, 4));
			Assert.AreEqual(keys['y'], new Tuple<int, int>(0, 5));
			Assert.AreEqual(keys['u'], new Tuple<int, int>(0, 6));
			Assert.AreEqual(keys['i'], new Tuple<int, int>(0, 7));
			Assert.AreEqual(keys['o'], new Tuple<int, int>(0, 8));
			Assert.AreEqual(keys['p'], new Tuple<int, int>(0, 9));
			Assert.AreEqual(keys['å'], new Tuple<int, int>(0, 10));
			Assert.AreEqual(keys['a'], new Tuple<int, int>(1, 0));
			Assert.AreEqual(keys['s'], new Tuple<int, int>(1, 1));
			Assert.AreEqual(keys['d'], new Tuple<int, int>(1, 2));
			Assert.AreEqual(keys['f'], new Tuple<int, int>(1, 3));
			Assert.AreEqual(keys['g'], new Tuple<int, int>(1, 4));
			Assert.AreEqual(keys['h'], new Tuple<int, int>(1, 5));
			Assert.AreEqual(keys['j'], new Tuple<int, int>(1, 6));
			Assert.AreEqual(keys['k'], new Tuple<int, int>(1, 7));
			Assert.AreEqual(keys['l'], new Tuple<int, int>(1, 8));
			Assert.AreEqual(keys['ö'], new Tuple<int, int>(1, 9));
			Assert.AreEqual(keys['ä'], new Tuple<int, int>(1, 10));
			Assert.AreEqual(keys['z'], new Tuple<int, int>(2, 0));
			Assert.AreEqual(keys['x'], new Tuple<int, int>(2, 1));
			Assert.AreEqual(keys['c'], new Tuple<int, int>(2, 2));
			Assert.AreEqual(keys['v'], new Tuple<int, int>(2, 3));
			Assert.AreEqual(keys['b'], new Tuple<int, int>(2, 4));
			Assert.AreEqual(keys['n'], new Tuple<int, int>(2, 5));
			Assert.AreEqual(keys['m'], new Tuple<int, int>(2, 6));
		}


	}
}
