public class TopKFrequent(int[] nums, int k)
{
    int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
    int k = 2;

    /// Using Sorting
    /// Time complexity: O(n log n) where n is the number of elements in nums
    public int[] UsingSort()
    {
        // Create a dictionary to store frequency of each number
        var frequencyMap = new Dictionary<int, int>();

        // Count the frequency of each number in the array
        foreach (int num in nums)
        {
            if (frequencyMap.ContainsKey(num))
            {
                frequencyMap[num]++;
            }
            frequencyMap[num] = 1;
        }

        // Sort the dictionary by frequency in descending order and take the top k elements
        var sortedByFrequency = frequencyMap.OrderByDescending(pair => pair.Value).Take(k);

        // Extract the keys (numbers) from the sorted pairs
        int[] result = sortedByFrequency.Select(pair => pair.Key).ToArray();

        return result;
    }
}   
