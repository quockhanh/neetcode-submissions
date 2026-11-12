// 4. Hash Map (One Pass) - Best
// Intuition
// We can solve the problem in a single pass by iterating through the array and checking if the
// complement of the current element exists in the hash map.

// If it does, we return the indices of the current element and its complement. If not, we store the
// current element in the hash map. This guarantees that we will never use the same element twice,
// but we still check every element in the array.

// Algorithm
// - Create a hash map to store the value and index of each element in the array.
// - Iterate through the array using index i and compute the complement of the current element,
// which is target - nums[i].
// - Check if the complement exists in the hash map.
// - If it does, return the indices of the current element and its complement.
// - If no such pair is found, return an empty array.
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // 1. Create a hash map to store value and index
        var map = new Dictionary<int, int>();

        // 2. Iterate through the array
        for (int i = 0; i < nums.Length; i++) {
            // 3. Calculate complement
            int complement = target - nums[i];

            // 4. Check if complement exists in the hash map
            if (map.TryGetValue(complement, out int j)) {
                // Return smaller index first
                return new[] { j, i };
            }

            // 5. Store current value and index
            map[nums[i]] = i;
        }

        // 6. No solution found
        return Array.Empty<int>();
    }
}
