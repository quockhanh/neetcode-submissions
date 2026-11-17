// 2. Sliding Window (Good)
// - we can keep one window that always has unique characters.
// - We expand the window by moving the right pointer.
// - If we ever see a repeated character, we shrink the window from the left until the duplicate is removed.
// - This way, the window always represents a valid substring, and we track its maximum size.
// - It's efficient because each character is added and removed at most once.
// Test case: abcdecfgg
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length < 2) {
            return s.Length;
        }

        // Now, at least 2 characters
        int l = 0;
        int r = 1;

        // to keep track of characters currently inside the sliding window 
        // and quickly check whether a character is duplicated.
        HashSet<char> set = new();
        set.Add(s[0]);

        int result = 1;
        while (r < s.Length) {
            char currentChar = s[r];
            while (set.Contains(currentChar)) {
                set.Remove(s[l]);
                l++;
            }

            set.Add(currentChar);

            result = Math.Max(result, r - l + 1);
            r++;
        }

        return result;
    }
}
