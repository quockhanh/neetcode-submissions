// 1. Sorting
// Intuition
// To find the k most frequent elements, we first need to know how often each number appears.
// Once we count the frequencies, we can sort the unique numbers based on how many times they occur.
// After sorting, the numbers with the highest frequencies will naturally appear at the end of the
// list. By taking the last k entries, we get the k most frequent elements.

// This approach is easy to reason about:
// count the frequencies → sort by frequency → take the top k.

// Algorithm
// 1. Create a hash map to store the frequency of each number.
// 2. Build a list of [frequency, number] pairs from the map.
// 3. Sort this list in ascending order based on frequency.
// 4. Create an empty result list.
// 5. Repeatedly pop from the end of the sorted list (highest frequency) and append the number to
// the result.
// 6. Stop when the result contains k elements.
// 7. Return the result list.

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

        // 2. Build and sort the list by frequency (descending)
        // Format: (Frequency, Number)
        var sortedList = frequency
            .Select(x => (Frequency: x.Value, Number: x.Key))
            .OrderByDescending(x => x.Frequency)
            .ToList();

        // 3. Take the top k most frequent numbers
        return sortedList
            .Take(k)
            .Select(x => x.Number)
            .ToArray();
    }
}

