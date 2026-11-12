// 3. Hash Map (Two Pass) - Better
// Intuition
// We can use a hash map to store the value and index of each element in the array. Then, we can
// iterate through the array and check if the complement of the current element exists in the hash
// map. The complement must be at a different index, because we can't use the same element twice.

// By using a hashmap, we can achieve a time complexity of O(n) because the insertion and lookup
// time of a hashmap is O(1).

// Algorithm
// - Create a hash map to store the value and index of each element in the array.
// - Iterate through the array and compute the complement of the current element, which is target -
// nums[i].
// - Check if the complement exists in the hash map.
// - If it does, return the indices of the current element and its complement.
// - If no such pair is found, return an empty array.
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // 1. Create a hash map to store value and index
        var map = new Dictionary<int, int>();

        // 2. First pass: populate the hash map
        for (int i = 0; i < nums.Length; i++) {
            map[nums[i]] = i;
        }

        // 3. Second pass: find the complement
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            // 4. Check if complement exists at a different index
            if (map.TryGetValue(complement, out int j) && i != j) {
                return new[] { i, j };
            }
        }

        // 5. No solution found
        return Array.Empty<int>();
    }
}
