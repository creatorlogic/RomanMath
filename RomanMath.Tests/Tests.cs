using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CheckOnNotAllowedSymbols_ReturnsTrue()
		{
			// Arrange
			string expression = "X*Q";
			bool expected = true;

			// Act
			var actual = Service.IsNotAllowedSymbols(expression);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CheckOnNotAllowedSymbols_ReturnsFalse()
		{
			// Arrange
			string expression = "X*V";
			bool expected = false;

			// Act
			var actual = Service.IsNotAllowedSymbols(expression);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Convert_From_RomanNumber_To_DigitalNumber()
		{
			// Arrange
			string expression = "CXXV";
			int expected = 125;

			// Act
			var actual = 0;
			for (int i = 0; i < expression.Length; i++)
			{
				var number = Service.ConvertFromRomanToDigital(expression[i].ToString());
				actual += number;
			}

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Evaluate_Add_TwoNumbers_ReturnsSumOfNumbers()
		{
			// Arrange
			string expression = "I+II";
			int expected = 3;

			// Act
			var actual = Service.Evaluate(expression);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}