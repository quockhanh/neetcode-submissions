// 1. Sorting
// Intuition
// Anagrams become identical when their characters are sorted.
// For example, "eat", "tea", and "ate" all become "aet" after sorting.
// By using the sorted version of each string as a key, we can group all anagrams together.
// Strings that share the same sorted form must be anagrams, so placing them in the same group is
// both natural and efficient.

// Algorithm
// - Create a hash map where each key is the sorted version of a string, and the value is a list of
// strings belonging to that anagram group.
// - Iterate through each string in the input list:
// - Sort the characters of the string to form a key.
// - Append the original string to the list corresponding to this key.
// - After processing all strings, return all values from the hash map, which represent the grouped
// anagrams.

public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var groups = new Dictionary<string, List<string>>();

        foreach (var str in strs) {
            // Sort characters to create the anagram key
            var key = new string(str.OrderBy(c => c).ToArray());

            if (!groups.ContainsKey(key)) {
                groups[key] = new List<string>();
            }

            groups[key].Add(str);
        }

        return groups.Values.ToList();
    }
}
