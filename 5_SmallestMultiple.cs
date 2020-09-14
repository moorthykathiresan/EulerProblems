using System;
using System.Collections.Generic;
					
public class Program
{
  /*Problem Statement:
  2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

  What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?  
  */
	public static void Main()
	{
		var max = 20;
		var smallestEvenlyDivisableNumber = SmallestEvenlyDivisableNumber(max);
		
		Console.WriteLine("Smallest Evenly divisable Number: " + smallestEvenlyDivisableNumber);
	}
	
	private static int SmallestEvenlyDivisableNumber(int max)
	{
		if(max <= 2)
		{
			return max;
		}
		
		var result = 1;
		var list = new List<int>{ 2 };
		
		for(var  i = 3; i <= max; i++)
		{
			var divisableFound = false;
			var divisableUnit = 1;
			var needsAppend = false;
			foreach(var item in list)
			{
				if(divisableFound)
				{
					if(divisableUnit * item == i)
					{
						needsAppend = false;
						break;
					}
					else if(i % (divisableUnit * item) == 0)
					{
						divisableUnit *= item;
					}
					else
					{
						needsAppend = true;
					}
				}
				else if(i % item == 0)
				{
					divisableFound = true;
					divisableUnit = item;
				}
			}
			if(!divisableFound)
			{
				list.Add(i);
			}
			else if(needsAppend)
			{
				list.Add(i / divisableUnit);
			}
		}
		
		foreach(var item in list)
		{
			result *= item;
		}
		return result;
	}	
}
