// 4. Prefix & Suffix (Optimal) -> Best for interview
// Intuition
// We can compute the product of all elements except the current one without using extra prefix and
// suffix arrays. Instead, we reuse the result array and build the answer in two simple passes:

// In the first pass, we fill res[i] with the product of all elements to the left of i (prefix
// product). In the second pass, we multiply each res[i] with the product of all elements to the
// right of i (postfix product).

// By maintaining two running values — prefix and postfix — we avoid the need for separate pref and
// suff arrays. This gives us the same logic as the previous method, but with O(1) extra space.

// *** You don't need to store all prefix and suffix products. You only need to remember the running
// product on each side.

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];

        int prefix = 1;

        // First pass: Calculate prefix products
        for (int i = 0; i < n; i++) {
            res[i] = prefix;
            prefix *= nums[i];
        }

        int postfix = 1;

        // Second pass: Calculate postfix products
        for (int i = n - 1; i >= 0; i--) {
            res[i] *= postfix;
            postfix *= nums[i];
        }

        return res;
    }
}
