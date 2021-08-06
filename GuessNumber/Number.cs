using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessNumber
{
	public class Number
	{
		public string Message { get; private set; }
		public int NumberGuessed { get; private set; }
		public bool WinFlag { get; private set; }
		private int AttemptCount { get; set; }
		private int NumberUser { get; set; }

		public Number(int attempts = Int32.MaxValue, int maxRandomValue = 100)
		{
			NumberUser = NumberGuessed = 0;
			AttemptCount = attempts;

			WinFlag = false;
			Message = "";
			NumberGuessed = new Random().Next(0, maxRandomValue);
		}


		public string Guess(string numberUserStr)
		{
			if (!IsNumber(numberUserStr)) { return Message; }

				if (NumberGuessed == NumberUser)
				{
					ExecuteWin();
				}
				else if (NumberGuessed > NumberUser)
				{
					AttemptCount = AttemptCount == Int32.MaxValue ? AttemptCount :  AttemptCount--;
					Message = $"Your number is less than guessed number. {(AttemptCount == 0 ? "" : "You have more one chance!")}";
				}
				else
				{
					AttemptCount = AttemptCount == Int32.MaxValue ? AttemptCount :  AttemptCount--;
					Message = $"Your number is bigger than guessed number. {(AttemptCount == 0 ? "" : "Try it more!")}";
				}

				PrintNumberComputer();
			return Message;
		}


		private bool IsNumber(string numberUserStr)
		{
			bool isNumberNumberFlag = false;
			
			int numberUser;
			Int32.TryParse(numberUserStr, out numberUser);
			NumberUser = numberUser;

			isNumberNumberFlag = !(NumberUser < 0 || numberUserStr.ToCharArray().Where(e => !Char.IsDigit(e)).Count() > 0);
			Message = isNumberNumberFlag ? Message : $@"{numberUserStr} is invalid data! Try again!{Environment.NewLine}";

			return isNumberNumberFlag;
		}


		private void ExecuteWin()
		{
			WinFlag = true;
			Message = $" *** Congrats! You WIN! *** ";
		}


		private void PrintNumberComputer()
		{
			if (!WinFlag && AttemptCount == 0)
			{
				Message +=$"{Environment.NewLine}Guessed number is {NumberGuessed}{Environment.NewLine}You will got luck next time!";
			}
		}
	}
}

