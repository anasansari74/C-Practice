using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Contains Duplicates
/// https://neetcode.io/practice/contains-duplicates
/// Given a list of numbers, I am using different methods to check for duplicates.
/// I am also trying to find the time and space complexity of each method.
/// Current ranking:
/// 1. Hash sets & LINQ GroupBy (tied)
/// 2. Nested For Loops
/// </summary>
public class ContainsDuplicates {
    /**
    Nested For Loops (brute force approach)
    Best case: Linear complexity O(n)
    Worst case: Quadratic complexity O(n²)
    Space complexity: Constant O(1)
    **/
    public bool usingNestedLoops(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] == nums[j]) {
                    return true;
                }
            }
        }
        return false;
    }

    /**
    LINQ GroupBy 
    Best case: Constant complexity O(1)
    Average case: Linear complexity O(n)
    Worst case: Quadratic complexity O(n²) - extremely rare as this means all items are the same
    Space complexity: Linear O(n)
    **/
    public bool usingGroupBy(int[] nums) {
        if (nums.GroupBy(r=>r).Any(g=>g.Count()>1)){
            return true;
        }
        return false;
    }

    /**
    Hash sets:
    Best & Average case: Constant O(1)
    Worst case: Linear O(n) all items have hash collisions/are the same
    Space complexity: Linear O(n)
    **/
    public bool usingHashSet(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in nums) {
            if (seen.Contains(num)) {
                return true;
            }
            seen.Add(num);
        }
        return false;
    }
}