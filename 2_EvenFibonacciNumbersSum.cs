using System;
using System.Collections.Generic;
					
public class Program
{
	/* Problem Statement:
	Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
	
	1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

	By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
	*/
	public static void Main()
	{
		int sum = 0;
		
		var fibSeq = GetFibSeq(4000000);
		
		foreach(var data in seq)
		{
			if(data % 2 == 0)
			{
				sum += data;
			}
		}
		
		Console.WriteLine(sum);
	}
	
	public static IEnumerable<int> GetFibSeq(int max)
	{
		var fibSeq = new List<int>();
		var start = 1;
		var next = 1;
		fibSeq.Add(start);
		fibSeq.Add(next);
		while(next + start < max)
		{
			var prevNext = next;
			next += start;
			fibSeq.Add(next);
			start = prevNext;
		}
		
		return fibSeq;
	}
		
}
