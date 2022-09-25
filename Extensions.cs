using System.Text;

namespace HaikuExtensions
{
    public static class StringExtension
    {
        public static string StripPunctuation(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }

    public static class CharExtension
    {
        public static bool IsVowel(this char s)
        {
            return "aeiouAEIOU".IndexOf(s) >= 0;
        }
    }


}
