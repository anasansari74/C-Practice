/// <summary>
/// Group Anagrams
/// Given an array of strings strs, group the anagrams together. You can return the answer in any order.
/// An Anagram is a word or phrase formed by rearranging the letters of a different word
/// than the original word.
/// Ranking:    
/// 1. Without Sorting Approach - O(n * k) time, O(n) space
/// 2. Sorting Approach - O(n * k log k) time, O(n) space
/// </summary>
public class GroupAnagrams {
    string[] strs = new string[] {"eat", "tea", "tan", "ate", "nat", "bat"};

    /**    
    Using Sorting    
    Time complexity: O(n * k log k) where n is the number of strings and k is the maximum length of a string in strs    
    Space complexity: O(n)
    **/
    public List<List<string>> UsingSort() {
        // Create a dictionary to store all anagrams
        var allAnagrams = new Dictionary<string, List<string>>();

        // Loop through the words in the given list
        foreach (string word in strs){
            // Sort the word to get a key
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            string sorted = new string(chars);

            // Check to see if the sorted anagram key exists
            if(!allAnagrams.ContainsKey(sorted)){
                // If yes, add the value to the key
                allAnagrams[sorted] = new List<string>();
            }
            // If no, create a new key which is the sorted string, and add the actual word to the list of values
            allAnagrams[sorted].Add(word);
        }

        return new List<List<string>>(allAnagrams.Values);
    }

    /**
    Without Sorting
    Time complexity: O(n * k) where n is the number of strings and k is the maximum length of a string in strs
    Space complexity: O(n)
    **/
    public List<List<string>> NoSorting()
    {
        // Create a dictionary to store all anagrams
        var allAnagrams = new Dictionary<string, List<string>>();

        foreach (string word in strs)
        {
            // Create frequency array for 26 letters
            int[] charCount = new int[26];

            // Count each letter in the word
            foreach (char c in word)
            {
                charCount[c - 'a']++;
            }

            // Convert frequency array to unique key    
            string key = string.Join("#", charCount);

            if (!allAnagrams.ContainsKey(key))
            {
                allAnagrams[key] = new List<string>();
            }
            allAnagrams[key].Add(word);
        }

        return new List<List<string>>(allAnagrams.Values);
    }
}