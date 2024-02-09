using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class Game
	{
		public int ComputerStep { get; set; }
		public int UserStep { get; set; }
		public int CountStep { get; set; }
		public Game(int computerStep,int userStep,int countStep) 
		{ 
			ComputerStep = computerStep;
			UserStep = userStep;
			CountStep = countStep;
		}
		public int GetWinner()
		{
			int p = (CountStep - 1) / 2;
			return (ComputerStep - UserStep + p + CountStep) % CountStep - p;
		}
	}
}
