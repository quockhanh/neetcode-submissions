// 1. Reverse String
public class Solution {
    public bool IsPalindrome(string s) {
        string newStr = "";
        foreach (char c in s) {
            if (char.IsLetterOrDigit(c)) {
                newStr += char.ToLower(c);
            }
        }

        return newStr == new string(newStr.Reverse().ToArray());
    }
}
