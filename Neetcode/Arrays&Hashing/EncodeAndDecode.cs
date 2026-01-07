using System;
using System.Collections.Generic;
using System.Text;

public static class EncodeAndDecode
{
    // Encode and Decode Strings using Length-Prefix Method
    // Time complexity: O(n) where n is the total length of all strings
    // Space complexity: O(n)
    public static (string encoded, IList<string> decoded) UsingLengthPrefix(IList<string> strs)
    {
        // Encode: for each string append "<length>:<string>"
        var sb = new StringBuilder();
        foreach (var s in strs)
        {
            sb.Append(s.Length);
            sb.Append(':');
            sb.Append(s);
        }
        var encoded = sb.ToString();

        // Decode: parse length then substring
        var decoded = new List<string>();
        int i = 0;
        while (i < encoded.Length)
        {
            int j = i;
            while (j < encoded.Length && encoded[j] != ':') j++;
            var lenStr = encoded.Substring(i, j - i);
            int len = int.Parse(lenStr);
            j++; // skip ':'
            var str = encoded.Substring(j, len);
            decoded.Add(str);
            i = j + len;
        }

        return (encoded, decoded);
    }
}
