/*
Given two strings, str1, and str2, where str1 contains exactly one character more than str2, find the indices of the characters in str1 that can be removed to make str1 equal to str2. Return the array of indices in increasing order. If it is not possible, return the array [-1]. 

Note: Use 0-based indexing.

Example

str1 = "abdgggda" str2 = "abdggda"

Any "g" character at positions 3, 4, or 5 can be deleted to obtain str2. Return [3, 4, 5].

Input Format

Function Description

Complete the function getRemovableIndices in the editor below.

getRemovableIndices has the following parameters:

string str1: the string to modify
string str2: the target string
Constraints

Constraints

2 ≤ |str1| ≤ 2 * 10^5
1 ≤ |str2| ≤ 2 * 10^5
|str1| = |str2| + 1 
str1 and str2 only contain lowercase English letters.
Output Format

Output Format

     int[]: the indices of characters that can be removed from str1 in ascending order, or [-1] if it is not possible to match str2

Sample Input 0

aabbb
aabb
Sample Output 0

2
3
4
Explanation 0

From str1, a character at indices 2, 3, or 4 can be removed to make it equal to str2.

Sample Input 1

mmgghh
mfggh
Sample Output 1

-1
Explanation 1

There is no way to make str1 equal to str2 by removing any 1 character.
*/

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getRemovableIndices' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. STRING str1
     *  2. STRING str2
     */
    
    public struct DIFF_VALUES
    {
        public char Char;
        public int Index;
    }
    
    public static DIFF_VALUES GetDIFF_VALUES(string str1, string str2)
    {
        DIFF_VALUES diff;        
        diff.Char = '\0';
        diff.Index = -1;        
        
        for(var i= 0; i < str1.Length; i++)
        {
            // Final index str1
            if(i == str1.Length - 1
                && str1.Substring(0, str1.Length-1).Equals(str2))
            {
                
                diff.Index = i;
                diff.Char = str1[i];
            }
            else
            {
                if(!str1[i].Equals(str2[i]))
                {
                    var sub1 = str1.Remove(i, 1);
                    if((sub1).Equals(str2))
                    {
                        diff.Index = i;
                        diff.Char = str1[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        
        return diff;
    }
    
    public static int FindDiffStart(string str1, int diffIndex, char diffChar)
    {
        for(var i = diffIndex - 1; i >= 0; i --)
        {
            if(!str1[i].Equals(diffChar))
            {
                break;
            }
            else
            {
                diffIndex = i;    
            }
        }
        return diffIndex;
    }
    
    public static List<int> getRemovableIndices(string str1, string str2)
    {
        var result = new List<int>();
        var diff = GetDIFF_VALUES(str1, str2);   
        
        if(diff.Index == -1)
        {
            result.Add(-1);
            return result;
        }
                
        var diffStart = FindDiffStart(str1, diff.Index, diff.Char);        
        // No duplicate        
        if(diffStart == diff.Index)
        {
            result.Add(diffStart);
            return result;
        }

        result.AddRange(Enumerable.Range(diffStart, diff.Index-diffStart+1));
        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string str1 = Console.ReadLine();

        string str2 = Console.ReadLine();

        List<int> result = Result.getRemovableIndices(str1, str2);

        Console.WriteLine(String.Join("\n", result));
    }
}
