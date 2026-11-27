// 2. Sliding window
// countT: to count the frequency of each character in `t`.
// countW: to count the frequency of each character in sliding window.
//
// sliding window starts from left, and spreads to right side, until it becomes valid window.
// sliding window is valid if: for each character in `t`,
//   the number of appearance in `t` = number of appearance in windows
// while window is valid, let's shrink from left to get minimum length, track the smallest one
// if window becomes invalid, then continuely spreads to right side to find more answers
// Test case:
// t = XYYZ
// s = aXbYbYbZcXXYYdZ
// first result = XbYbYbZ => 7
// then ... (many results)
// final result: XYYdZ => 5
public class Solution {
    public string MinWindow(string s, string t) {
        if (t.Length == 0 || s.Length < t.Length) {
            return "";
        }

        // Count number of appearance in `t` and window
        // Key: character
        // Value: number of appearance
        Dictionary<char, int> countT = new();
        Dictionary<char, int> countW = new();

        // Count in `t` first
        foreach (char c in t) {
            countT[c] = countT.GetValueOrDefault(c) + 1;
        }

        int have = 0;  // Number of character in t, which already meets required count in window
        int need = countT.Count;  // Number of character (as key) in t

        // To return shortest string,
        // we need to track its length and start index
        int resLen = int.MaxValue;  // default as Max, because we want to find shortest length
        int resStart = 0;

        int l = 0;
        for (int r = 0; r < s.Length; r++) {
            // Count it in window first
            char c = s[r];
            countW[c] = countW.GetValueOrDefault(c) + 1;

            // Compare with the count in `t`
            // If matches, then we increase `have` (one more character counts done)
            if (countT.ContainsKey(c) && countW[c] == countT[c]) {
                have++;
            }

            // If this window contains required count (valid mode):
            // - firstly, track the result
            // - then, we try to shrink window from left side, WHILE IT IS STILL VALID,
            // to find the minimum length
            // 
            // - pickup left character
            // - move left pointer forwardly, and remember to:
            //   + decrease its count in window
            //   + this count decreasement may affect to `have` (turn window to invalid mode)
            while (have == need) {
                int len = r - l + 1;
                if (len < resLen) {
                    resLen = len;
                    resStart = l;
                }

                char leftChar = s[l];

                countW[leftChar]--;
                if (countT.ContainsKey(leftChar) && countW[leftChar] < countT[leftChar]) {
                    have--;
                }

                l++;
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(resStart, resLen);
    }
}
