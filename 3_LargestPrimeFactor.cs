using System;
					
public class Program
{
  /* Problem Statement:
  The prime factors of 13195 are 5, 7, 13 and 29.

  What is the largest prime factor of the number 600851475143 ?  
  */
	public static void Main()
	{
		var primeNumber = 600851475143;
		var biggestPrimeFactor = BiggestPrimeFactor(primeNumber);
		
		Console.WriteLine("Biggest Prime Factor: " + biggestPrimeFactor);
	}
	
	private static long BiggestPrimeFactor(long primeNumber)
	{
		long biggestPrimeFactor = 0;
		
		// Keep dividing the primeNumber by 2 if it's dividable by 2
		while(primeNumber % 2 ==0)
		{
			primeNumber /= 2;
			biggestPrimeFactor = 2;
		}
		
		// Now the number must be odd, so start with 3 till Sqrt of the number and keep incrementing by 2
		for(var i = 3; i < Math.Sqrt(primeNumber); i += 2)
		{
			if(primeNumber % i == 0)
			{
				primeNumber /= i;
				if(i > biggestPrimeFactor)
				{
					biggestPrimeFactor = i;
				}
			}
		}
		
		if(primeNumber > biggestPrimeFactor)
		{
			biggestPrimeFactor = primeNumber;
		}
		
		return biggestPrimeFactor;
	}
}
