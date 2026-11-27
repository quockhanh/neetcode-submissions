// 3. Sliding Window (Optimal)
// While expanding the window, we track:
// - the frequency of each character,
// - the highest frequency we have seen in the window as it grows (maxf).
// Check whether sliding-window is valid or not, it is valid if:
//   "window size – count of the most frequent character ≤ k"
// - If valid, then expand right-pointer
// - Otherwise, let's shrink from the left
public class Solution {
    public int CharacterReplacement(string s, int k) {
        // Key: character
        // Value: number of appearance
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int result = 0;

        int maxf = 0; // highest frequency
        int l = 0;
        for (int r = 0; r < s.Length; r++) {
            // Get character at right pointer and count the appearance
            char currentChar = s[r];
            dict[currentChar] = dict.GetValueOrDefault(currentChar) + 1;

            // Update maxf if needed, because we just update the counter
            maxf = Math.Max(maxf, dict[currentChar]);

            while ((r - l + 1) - maxf > k) {
                // Shrink sliding windows from left side
                dict[s[l]]--;
                l++;
            }

            // We dont need to update maxf again, after shrinking window from left side.
            // maxf may be stale.
            // However, final answer is still correct. Because:
            // 1. maxf only increases when we find a higher character frequency.
            // 2. That higher frequency was achieved in an actual window.
            // 3. The algorithm never increases the window size beyond the maximum length previously achievable with that historical frequency.
            // 4. Therefore, a stale maxf cannot produce an answer larger than the true optimum.

            // track the longest result
            result = Math.Max(result, r - l + 1);
        }

        return result;
    }
}
