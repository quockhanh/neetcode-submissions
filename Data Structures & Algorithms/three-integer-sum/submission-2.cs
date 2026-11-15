// 3. Two Pointers
// Intuition
// After sorting the array, we can fix one number and then search for the other two using the two-pointer technique.
// Sorting helps in two ways:
// 1. It lets us skip duplicates easily.
// 2. It ensures that moving the left or right pointer will increase or decrease the sum in a predictable way.

// For each fixed number a, we place two pointers:
// - l starts just after i,
// - r starts at the end.

// If the current sum is too large, we move r left to reduce it.
// If the sum is too small, we move l right to increase it.
// When the sum is exactly zero, we record the triplet and skip duplicates.
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        var result = new List<List<int>>();

        // Sort array to use two-pointer technique
        // - Increase left point if num[l] + num[r] < target
        // - Decrease right point if num[l] + num[r] > target
        Array.Sort(nums);
        
        // Length - 2, because after i, we try to lookup j and k
        for (int i = 0; i < nums.Length - 2; i++)
        {
            // All remaining numbers are positive. Let's skip
            if (nums[i] > 0) {
                // Because array is sorted, example we have:
                // [-4, -1, -1, 0, 1, 2]
                // if nums[i] > 0, then there are not nums[j] and number[k] meet requirement
                // Cannot nums[i] == 0, because [0, 0, 0] is still valid result
                break;
            }

            // Skip duplicate, we proceeded it
            if (i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }

            int l = i + 1;
            int r = nums.Length - 1;

            while (l < r)
            {
                int target = -nums[i];
                int sum = nums[l] + nums[r];

                if (nums[l] + nums[r] > target)
                {
                    r--;
                    continue;
                }

                if (nums[l] + nums[r] < target)
                {
                    l++;
                    continue;
                }
                
                // = target. Let's add to result list
                result.Add(new List<int>
                {
                    nums[i],
                    nums[l],
                    nums[r]
                });

                l++;
                r--;

                // Skip duplicate left values.
                while (l < r && nums[l] == nums[l - 1]) {
                    l++;
                }

                // Skip duplicate right values.
                while (l < r && nums[r] == nums[r + 1]) {
                    r--;
                }
            }
        }

        return result;
    }
}
