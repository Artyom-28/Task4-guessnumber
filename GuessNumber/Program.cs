using System;
using System.Collections.Generic;

namespace GuessNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			bool quitForceFlag = false;
			Number number = new Number();

			do
			{
				Console.Write($@"Enter your not negative integer number: ");
				number.Guess(Console.ReadLine());

				if(number.WinFlag)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine(number.Message);
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine($"Play again and guess the next number!");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"YES - press any kye!");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"No - press 'n' or 'N' key{Environment.NewLine}");
					Console.ForegroundColor = ConsoleColor.Gray;
					quitForceFlag = new List<char>() { 'n', 'N' }.Contains(Console.ReadKey().KeyChar);
					number = quitForceFlag ? number : new Number();
					Console.WriteLine();
				}
				else
				{
					Console.WriteLine(number.Message + Environment.NewLine);
				}
			}
			while (!number.WinFlag && !quitForceFlag);
		}
	}
}
