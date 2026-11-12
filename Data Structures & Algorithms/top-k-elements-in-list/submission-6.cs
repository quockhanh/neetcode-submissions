// 2. Min-Heap (Best)
// Intuition
// After counting how often each number appears, we want to efficiently keep track of only the k most frequent elements.
// A min-heap is perfect for this because it always keeps the smallest element at the top.
// By pushing (frequency, value) pairs into the heap and removing the smallest whenever the heap grows beyond size k, we ensure that the heap always contains the top k most frequent elements.
// In the end, the heap holds exactly the k values with the highest frequencies.

// Algorithm
// - Build a frequency map that counts how many times each number appears.
// - Create an empty min-heap.
// - For each number in the frequency map:
// - Push (frequency, number) into the heap.
// - If the heap size becomes greater than k, pop once to remove the smallest frequency.
// - After processing all numbers, the heap contains the k most frequent elements.
// - Pop all elements from the heap and collect their numbers into the result list.
// - Return the result.

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

        // 2. Create a min-heap (Label = number, Priority = frequency)
        // Smallest frequency has highest priority
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        // 3. Keep only the k most frequent elements
        foreach (var item in frequency)
        {
            minHeap.Enqueue(item.Key, item.Value);
            if (minHeap.Count > k)
            {
                // Remove the hisgest priority = smallest frequency
                minHeap.Dequeue();
            }
        }

        // 4. Extract the remaining k elements
        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
    }
}
