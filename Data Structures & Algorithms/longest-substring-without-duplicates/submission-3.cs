// 3. Sliding Window (Optimal)
// Instead of removing characters one by one when we see a repeat, we can jump the left pointer directly to the correct position.
// We keep a map that stores the last index where each character appeared.
// When a character repeats, the earliest valid starting point moves to one position after its previous occurrence.
// This lets us adjust the window in one step and always keep it valid, making the approach fast and clean.

// Test case: abcdecfgg
// if 'c' is duplicated/found, the just left pointer to 'd'
// it is the next index, after last appearance of 'c'

// Summary: We still use sliding windows
// But we use Dictionary to move left pointer faster
public class Solution {
public int LengthOfLongestSubstring(string s)
{
    // Key: that character
    // Value: index of last appearance
    Dictionary<char, int> mp = new();

    int l = 0; // left pointer
    int result = 0;

    for (int r = 0; r < s.Length; r++)
    {
        char currentChar = s[r];
        if (mp.ContainsKey(currentChar))
        {
            l = Math.Max(l, mp[currentChar] + 1);

            // We cannot just use `l = mp[currentChar] + 1`, Because left point may move backwards
            // Given at this test case: "abba"
            // - At final step, when left_point = 3 and right_pointer = 4, currentChar = 'a'
            // - Dictionary is:
            //   'a': 0
            //   'b': 2
            // so if `l = mp[currentChar] + 1` then l = 0, it is wrong
            // we expect l = 3
        }

        mp[currentChar] = r; // Update last appearance index
        result = Math.Max(result, r - l + 1);
    }

    return result;
}
}
