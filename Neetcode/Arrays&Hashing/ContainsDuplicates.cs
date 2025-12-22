public class Solution {
    public bool hasDuplicate(int[] nums) {
        if (nums.GroupBy(r=>r).Any(g=>g.Count()>1)){
            return true;
        }
        return false;
    }
}