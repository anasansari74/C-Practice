/// <summary>
/// Top K Frequent Elements
/// Given an integer array nums and an integer k, return the k most frequent elements.
/// Current ranking:
/// 1. Using Bucket Sort - O(n) time complexity
/// 2. Using Sorting - O(n log n) time complexity
/// 3. Using Bubble Sort - O(n^2) time complexity
/// </summary>
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

    /// Using Bucket Sort
    /// Time complexity: O(n)   
    /// space complexity: O(n)
    public int[] UsingBucketSort()
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

        // Create buckets where index represents frequency
        List<int>[] buckets = new List<int>[nums.Length + 1];
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<int>();
        }

        // Place numbers into their corresponding frequency buckets
        foreach (var pair in frequencyMap)
        {
            int number = pair.Key;
            int frequency = pair.Value;
            buckets[frequency].Add(number);
        }

        // Collect the top k frequent elements from the buckets
        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
        {
            foreach (int num in buckets[i])
            {
                result.Add(num);
                if (result.Count == k)
                {
                    break;
                }
            }
        }

        return result.ToArray();
    }

    /// Using Bubble Sort
    /// Time complexity: O(n^2) where n is the number of unique elements in nums
    /// space complexity: O(n)
    /// The difference between bubble and bucket is that bubble sort is less efficient for large datasets.    
    public int[] UsingBubbleSort()
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

        // Convert the dictionary to a list of key-value pairs
        var freqList = frequencyMap.ToList();

        // Bubble sort the list based on frequency in descending order
        for (int i = 0; i < freqList.Count - 1; i++)
        {
            for (int j = 0; j < freqList.Count - i - 1; j++)
            {
                if (freqList[j].Value < freqList[j + 1].Value)
                {
                    // Swap
                    var temp = freqList[j];
                    freqList[j] = freqList[j + 1];
                    freqList[j + 1] = temp;
                }
            }
        }

        // Extract the top k elements
        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = freqList[i].Key;
        }

        return result;
    }
}   
