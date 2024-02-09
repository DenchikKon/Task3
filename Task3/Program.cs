using MoreLinq;
using System;
using System.Linq;

namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if ((args.Length < 3 && args.Length % 2 == 0) || args.Length == 1)
			{
				Console.WriteLine("Требуется ввести минимум 3 параметра\n" +
					"и количество параметром должно быть нечётным");
				Console.ReadKey();
				return;
			}
			if(args.Distinct().Count() != args.Length)
			{
				Console.WriteLine("В программе не может быть несколько одинаковых аргументов");
				Console.ReadKey();
				return;
			}
			SecureKey secureKey = new SecureKey(256);
			int computerStep = new Random().Next(args.Length);
			HMAC hmac = new HMAC(args[computerStep], secureKey, 256);
            Console.WriteLine($"HMAC: {hmac.Hmac}");
			int userStep;
			while (true)
			{
				Console.WriteLine("Avaible moves:");
				for (int i = 0; i < args.Length; i++)
				Console.WriteLine($"{i + 1} - {args[i]}");
				Console.WriteLine("0 - exit");
				Console.WriteLine("-1 - help");
				Console.Write("Enter your move: ");
				if (!int.TryParse(Console.ReadLine(), out int value))
					continue;
				else 
				{
					if (value == 0)
						return;
					else if (value == -1)
					{
						Table table = new Table(args);
						table.Generate();
						continue;
					}
					else if(value >= 0 && value <= args.Length)
					{
						userStep = value;
						break;
					}
					else
					{
						Console.WriteLine("Введены не корректные данные");
						continue;
					}
				}
			}
            Console.WriteLine($"Your move: {args[userStep - 1]}");
            Console.WriteLine($"Computer move: {args[computerStep]}");
			Game game = new Game(computerStep, userStep - 1,args.Length);
			int result = game.GetWinner();
			if (result > 0) Console.WriteLine("You win");
			else if(result == 0) Console.WriteLine("Draw");
            else if(result < 0) Console.WriteLine("You lose");
            Console.WriteLine("HMAC key: " + secureKey.HashKey);
            Console.ReadKey();
		}
	}
}
