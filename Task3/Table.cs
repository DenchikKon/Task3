using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class Table
	{
		public string[] Column { get; set; }
		public Table(string[] column) 
		{ 
			Column = column;
		}
		public void Generate()
		{
			List<string> data = new List<string>();
			int p = (Column.Length - 1) / 2;
			data.Add("");
			data.AddRange(Column);
			var table = new ConsoleTable();
			table.AddColumn(data);
			data.Clear();
			for (int i = 0; i < Column.Length; i++)
			{
				data.Add(Column[i]);
				for (int j = 0; j < Column.Length; j++)
				{
					Game game = new Game(i,j,Column.Length);
					int result = game.GetWinner();
					if (result > 0)
						data.Add("Win");
					else if (result < 0)
						data.Add("Lose");
					else if (result == 0)
						data.Add("Draw");
				}
				table.AddRow(data.ToArray());
				data.Clear();
			}
			table.Write();
		}
	}
}

