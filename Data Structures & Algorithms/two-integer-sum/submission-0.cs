// 2. Sorting
// Algorithm
// - Create a copy of the array and sort it in ascending order.
// - Initialize two pointers, one at the beginning (i) and one at the end (j) of the array.
// - Iterate through the array with the two pointers and check if the sum of the two numbers is
// equal to the target.
// - If the sum is equal to the target, return the indices of the two numbers.
// - If the sum is less than the target, move the left pointer i to the right, which will increase
// the sum.
// - If the sum is greater than the target, move the right pointer j to the left, which will
// decrease the sum.
// - There is guaranteed to be exactly one solution, so we will never return an empty array.
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Store original indices alongside values
        var sorted = nums.Select((value, index) => new { Value = value, Index = index })
                         .OrderBy(x => x.Value)
                         .ToArray();

        int left = 0;
        int right = sorted.Length - 1;

        while (left < right) {
            int sum = sorted[left].Value + sorted[right].Value;

            if (sum == target) {
                int i = sorted[left].Index;
                int j = sorted[right].Index;

                // Return smaller index first
                return i < j ? new[] { i, j } : new[] { j, i };
            }

            if (sum < target) {
                left++;
            } else {
                right--;
            }
        }

        // Guaranteed to have exactly one solution
        return Array.Empty<int>();
    }
}
