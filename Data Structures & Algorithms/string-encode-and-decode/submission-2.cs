// 1. Encoding & Decoding
public class Solution {
    public string Encode(IList<string> strs) {
        var lengths = strs.Select(s => s.Length);
        return string.Join(",", lengths) + "#" + string.Concat(strs);
    }

    public List<string> Decode(string s) {
        var result = new List<string>();

        if (string.IsNullOrEmpty(s)) {
            return result;
        }

        int separatorIndex = s.IndexOf('#');

        string lengthSection = s[..separatorIndex];
        if (string.IsNullOrEmpty(lengthSection)) {
            return result;
        }
        
        int[] lengths = lengthSection.Split(',').Select(int.Parse).ToArray();

        int start = separatorIndex + 1;
        foreach (int length in lengths) {
            result.Add(s.Substring(start, length));
            start += length;
        }

        return result;
    }
}
