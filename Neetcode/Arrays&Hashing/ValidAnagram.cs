using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Valid Anagrams
/// Given two strings, I am using different methods to check if they are anagrams of each other.
/// I am also trying to find the time and space complexity of each method.
/// Current ranking:
/// 1. Sorting
/// </summary>
public class ValidAnagram
{
    string s = "racecar";
    string t = "carrace";

    /**
    Sorting (simple approach)
    Best, Average & Worst case: O(n log n) due to sorting 
    Space: O(n) for storing character arrays 
    **/
    public bool UsingSort()
    {
        bool isAnagram = false;
    
    	if (s.Length != t.Length) return false;
                
        List<char> splitS = s.ToCharArray().ToList();
        List<char> splitT = t.ToCharArray().ToList();
        
        splitS.Sort();
        splitT.Sort();
            
        isAnagram = splitS.SequenceEqual(splitT);
            
        Console.WriteLine(isAnagram);
    }
}