using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Valid Anagrams
/// Given two strings, I am using different methods to check if they are anagrams of each other.
/// I am also trying to find the time and space complexity of each method.
/// Current ranking:
/// 1. Dictionary (Hash map)
/// 2. Sorting
/// </summary>
public class ValidAnagram
{
    string s = "racecar";
    string t = "carrace";

    /**
    Sorting (simple approach)
    Best, Average & Worst case: Logarithmic time complexity O(n log n) 
    Space complexity: Constant O(n) 
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
            
        return isAnagram;
    }

    /**
    Dictionary 
    Best, Average & Worst case: Linear time complexity O(n) 
    Space complexity: Constant O(n) 
    **/
    public bool usingDictionaries(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in s){
            if (charCount.ContainsKey(c)){
                charCount[c]++;
            }else{
                charCount[c] = 1;
            }
        }

        foreach (char c in t){
            if (!charCount.ContainsKey(c)){
                return false;
            }

            charCount[c]--;

            if (charCount[c] == 0){
                charCount.Remove(c);
            }
        }

        return charCount.Count == 0;
    }
}