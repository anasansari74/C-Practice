using System;
using System.Linq;

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
}