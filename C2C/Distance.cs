using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C2C
{
	public class Distance
	{
		private readonly double MaxDefaultVal = 10000;
		
		public double InputToMatchCost(Dictionary<char, Tuple<int, int>> keyboard, string input, string match)
		{
			if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(match))
			{
				return MaxDefaultVal;
			}

			if (input == match)
			{
				return 0;
			}

			Regex cleaner = new Regex("[^a-zA-Zåäö]+");

			input = cleaner.Replace(input.ToLower(), "");
			match = cleaner.Replace(match.ToLower(), "");

			double cost = 0;

			int shortestString = input.Length > match.Length ? match.Length : input.Length;

			Tuple<int, int> inputXY = new Tuple<int, int>(0, 0);
			Tuple<int, int> matchXY = new Tuple<int, int>(0, 0);

			for (int i = 0; i < shortestString; i++)
			{
				inputXY = keyboard[input[i]];
				matchXY = keyboard[match[i]];
				cost += CalculatePointToPointDistance(inputXY.Item1, inputXY.Item2, matchXY.Item1, matchXY.Item2);
			}
			return cost;
		}

		/// <summary>
		/// Sets up a dictionary with char & tuple where the tuple indicates a XY-coordinates at the keyboard. Q has X:0 and Y:0
		/// </summary>
		/// <returns></returns>
		public Dictionary<char, Tuple<int, int>> InitiateQWERTYDict()
		{
			Dictionary<char, Tuple<int, int>> keyboardMappings = new Dictionary<char, Tuple<int, int>>();

			keyboardMappings.Add('q', new Tuple<int, int>(0, 0));
			keyboardMappings.Add('w', new Tuple<int, int>(0, 1));
			keyboardMappings.Add('e', new Tuple<int, int>(0, 2));
			keyboardMappings.Add('r', new Tuple<int, int>(0, 3));
			keyboardMappings.Add('t', new Tuple<int, int>(0, 4));
			keyboardMappings.Add('y', new Tuple<int, int>(0, 5));
			keyboardMappings.Add('u', new Tuple<int, int>(0, 6));
			keyboardMappings.Add('i', new Tuple<int, int>(0, 7));
			keyboardMappings.Add('o', new Tuple<int, int>(0, 8));
			keyboardMappings.Add('p', new Tuple<int, int>(0, 9));
			keyboardMappings.Add('å', new Tuple<int, int>(0, 10));
			keyboardMappings.Add('a', new Tuple<int, int>(1, 0));
			keyboardMappings.Add('s', new Tuple<int, int>(1, 1));
			keyboardMappings.Add('d', new Tuple<int, int>(1, 2));
			keyboardMappings.Add('f', new Tuple<int, int>(1, 3));
			keyboardMappings.Add('g', new Tuple<int, int>(1, 4));
			keyboardMappings.Add('h', new Tuple<int, int>(1, 5));
			keyboardMappings.Add('j', new Tuple<int, int>(1, 6));
			keyboardMappings.Add('k', new Tuple<int, int>(1, 7));
			keyboardMappings.Add('l', new Tuple<int, int>(1, 8));
			keyboardMappings.Add('ö', new Tuple<int, int>(1, 9));
			keyboardMappings.Add('ä', new Tuple<int, int>(1, 10));
			keyboardMappings.Add('z', new Tuple<int, int>(2, 0));
			keyboardMappings.Add('x', new Tuple<int, int>(2, 1));
			keyboardMappings.Add('c', new Tuple<int, int>(2, 2));
			keyboardMappings.Add('v', new Tuple<int, int>(2, 3));
			keyboardMappings.Add('b', new Tuple<int, int>(2, 4));
			keyboardMappings.Add('n', new Tuple<int, int>(2, 5));
			keyboardMappings.Add('m', new Tuple<int, int>(2, 6));

			return keyboardMappings;
		}


		/// <summary>
		/// The distance formula.
		/// http://www.purplemath.com/modules/distform.htm
		/// </summary>
		/// <param name="x0"></param>
		/// <param name="y0"></param>
		/// <param name="x1"></param>
		/// <param name="y1"></param>
		/// <returns></returns>
		private double CalculatePointToPointDistance(int x0, int y0, int x1, int y1)
		{
			double deltaX = x0 - x1;
			double deltaY = y0 - y1;
			double powDeltas = deltaX * deltaX + deltaY * deltaY;
			double distance = Math.Round(Math.Sqrt(powDeltas), 2);
			return distance;
		}
	}
}
