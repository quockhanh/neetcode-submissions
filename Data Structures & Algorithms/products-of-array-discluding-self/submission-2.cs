// 3. Prefix & Suffix (Good - without using Division, not handle zero)
// Intuition
// For each index, we need the product of all elements before it and all elements after it.
// Instead of recomputing the product repeatedly, we can pre-compute two helpful arrays:

// Prefix product: pref[i] = product of all elements to the left of i
// Suffix product: suff[i] = product of all elements to the right of i
// Then, the final answer for each index is simply:

// result[i] = pref[i] × suff[i]

// This works because:

// The pref handles everything before the index
// The suff handles everything after the index
// Both pieces together form the product of all numbers except the one at that position.

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;

        int[] pref = new int[n];
        int[] suff = new int[n];
        int[] res = new int[n];

        // Initialize
        pref[0] = 1;
        suff[n - 1] = 1;

        // Calculate prefix products
        for (int i = 1; i < n; i++) {
            pref[i] = nums[i - 1] * pref[i - 1];
        }

        // Calculate suffix products
        for (int i = n - 2; i >= 0; i--) {
            suff[i] = nums[i + 1] * suff[i + 1];
        }

        // Calculate final result
        for (int i = 0; i < n; i++) {
            res[i] = pref[i] * suff[i];
        }

        return res;
    }
}
