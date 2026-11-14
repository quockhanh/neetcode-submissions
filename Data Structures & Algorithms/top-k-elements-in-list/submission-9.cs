// 3. Bucket Sort (Hard)
// Intuition
// Each number in the array appears a certain number of times, and the maximum possible frequency is the length of the array.
// We can use this idea by creating a list where the index represents a frequency, and at each index we store all numbers that appear exactly that many times.

// For example:
// - All numbers that appear 1 time go into group freq[1].
// - All numbers that appear 2 times go into group freq[2].
// - And so on.

// After we build these groups, we look from the highest possible frequency down to the lowest and collect numbers from these groups until we have k of them.
// This way, we directly jump to the most frequent numbers without sorting all the elements by frequency.

// Algorithm
// - Build a frequency map that counts how many times each number appears.
// - Create a list of groups freq, where freq[i] will store all numbers that appear exactly i times.
// - For each number and its frequency in the map, add the number to freq[frequency].
// - Initialize an empty result list.
// - Loop from the largest possible frequency down to 1:
//   + For each number in freq[i], add it to the result list.
//   + Once the result contains k numbers, return it.

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        // 1. Count the frequency of each number
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        // 2. Create buckets:
        // - index represents frequency
        // - value is list of number which appear exactly i times.
        // Why + 1? If `nums` has 6 items, then the frequency is from 0 to 6, that's why need 6 + 1 = 7
        List<int>[] buckets = new List<int>[nums.Length + 1];

        // 3. Group numbers by their frequency
        foreach (var item in frequency)
        {
            int freq = item.Value;
            int num = item.Key;

            buckets[freq] ??= new List<int>();
            buckets[freq].Add(num);
        }

        // 4. Collect the k most frequent numbers
        // Start from end of list to get TOP Frequently
        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i >= 1; i--)
        {
            if (buckets[i] == null) {
                // There is no number which appears i times
                continue;
            }

            foreach (int num in buckets[i])
            {
                result.Add(num);
                if (result.Count == k) {
                    return result.ToArray();
                }
            }
        }

        return result.ToArray();
    }
}

