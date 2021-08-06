using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessNumber;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumberTests
{
	[TestClass()]
	public class NumberTests
	{
		[TestMethod()]
		public void GuessTest_NumberUserBigger()
		{
			Number number = new Number();
			number.Guess((number.NumberGuessed + 1).ToString());
			string actual = number.Message;
			string expected = "Your number is bigger than guessed number. Try it more!";

			Assert.AreEqual(actual: actual, expected: expected);
		}


		[TestMethod()]
		public void GuessTest_NumberUserLess()
		{
			Number number = null;
			do
			{
				number = new Number();
			}
			while (number.NumberGuessed == 0);

			number.Guess((number.NumberGuessed - 1).ToString());
			string actual = number.Message;
			string expected = "Your number is less than guessed number. You have more one chance!";

			Assert.AreEqual(actual: actual, expected: expected);
		}


		[TestMethod()]
		public void GuessTest_Win()
		{
			Number number = new Number();
			number.Guess(number.NumberGuessed.ToString());
			string actual = number.Message;
			string expected = " *** Congrats! You WIN! *** ";

			Assert.AreEqual(actual: actual, expected: expected);
		}


		[TestMethod()]
		public void GuessTest_UncorrectData()
		{
			Number number = new Number();
			string uncorrectData = "z" + number.NumberGuessed;
			number.Guess(uncorrectData);
			string actual = number.Message;
			string expected = $"{uncorrectData} is invalid data! Try again!{Environment.NewLine}";

			Assert.AreEqual(actual: actual, expected: expected);
		}
	}
}