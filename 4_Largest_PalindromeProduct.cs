using System;
using System.Text;
					
public class Program
{
  /* Problem Statement:
  A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

  Find the largest palindrome made from the product of two 3-digit numbers.
  */
	public static void Main()
	{
		var digits = 3;
		var biggestPolyndromeNumber = BiggestPolyndromNumber(digits);
		
		Console.WriteLine("Biggest polyndrome Number: " + biggestPolyndromeNumber);
	}
	
	private static long BiggestPolyndromNumber(int maxDigit)
	{
		long biggestPolyndromeNumber = 0;
		
		var  biggestLeftNumber = long.Parse(new StringBuilder().Append('9', maxDigit).ToString());
		// example 99 (left) * i (right side of the product to find be found) 
		
		for(var i = biggestLeftNumber; i > 0; i--)
		{
			var product = i * biggestLeftNumber;
			if(IsPolyndrome(product))
			{
				biggestPolyndromeNumber = product;
				break;
			}
		}
		return biggestPolyndromeNumber;
	}
	
	private static bool IsPolyndrome(long number)
	{
		//Console.WriteLine(number);
		if(number == 0)
			return true;
		var stringRepresentation = number.ToString();
		
		//assume even length by default
		var mid = stringRepresentation.Length / 2;		
		var leftString = stringRepresentation.Substring(0, mid);
		var rightString = stringRepresentation.Substring(mid, mid);
		
		if(stringRepresentation.Length % 2 != 0) // override if it's odd length
		{
			mid = stringRepresentation.Length / 2 + 1;
			leftString = stringRepresentation.Substring(0, mid - 1);
			rightString = stringRepresentation.Substring(mid, mid - 1);
		}
		
		var reversed = rightString.ToCharArray();
		Array.Reverse(reversed);
		
		return leftString.Equals(new string(reversed));
	}
}
