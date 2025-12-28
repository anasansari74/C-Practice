using System.Collections.Generic;

/// <summary>
/// Two Sum
/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
/// You may assume that each input would have exactly one solution
/// Return the answer with smallest index first.
/// </summary>
public class TwoSum()
{
    int[] nums = {1,3,5,7,9};
    int target = 7;
    /**
    Brute Force - Nested For Loops
    Time complexity: Quadratic O(n²)
    Space complexity: Linear O(1)
    **/
    public int[] UsingNestedForLoops() {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[] { i, j };
                }
            }
        }
        return new int[0];
    }

    /**
    Using Dictionary
    Time complexity: Linear O(n)
    Space complexity: Linear O(n)
    **/
    public int[] UsingDictionary() {
        Dictionary<int, int> numDict = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            if (numDict.ContainsKey(complement)) {
                return new int[] { numDict[complement], i };
            }
            
            if (!numDict.ContainsKey(nums[i])) {
                numDict.Add(nums[i], i);
            }
        }

        return new int[0];
    }   
}