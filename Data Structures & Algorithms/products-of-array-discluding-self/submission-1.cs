// 2. Division (Very good)
// Intuition
// This approach works by using a simple idea:
// If we know the product of all non-zero numbers, we can easily compute the answer for each position using division — as long as there are no division-by-zero issues.

// So we first check how many zeros the array has:
// - If there are two or more zeros, then every product will include at least one zero → the entire res is all zeros.
// - If there is exactly one zero, then only the position containing that zero will get the product of all non-zero numbers. All other positions become 0.
// - If there are no zeros, we can safely do:
// result[i] = total_product // nums[i]

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int prod = 1;
        int zeroCount = 0;

        // Step 1: Calculate product of non-zero elements
        // and count zeros.
        foreach (int num in nums) {
            if (num == 0) {
                zeroCount++;
            } else {
                prod *= num;
            }
        }

        // Step 2: More than one zero.
        // The result is all zeros
        if (zeroCount > 1) {
            return new int[n];
        }

        int[] output = new int[n];

        // Step 3: Calculate the result.
        for (int i = 0; i < n; i++) {
            if (zeroCount == 1) {
                output[i] = nums[i] == 0 ? prod : 0;
            } else {
                output[i] = prod / nums[i];
            }
        }

        return output;
    }
}
