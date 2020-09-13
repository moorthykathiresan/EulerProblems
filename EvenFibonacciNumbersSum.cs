using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		int sum = 0;
		
		var seq = GetFibSeq(4000000);
		
		foreach(var data in seq)
		{
			if(data % 2 == 0)
			{				
				//Console.WriteLine(data);
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
