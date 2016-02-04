using System.Linq;

namespace Mobildev.SMS.Extensions
{
    public static class StringExtension
    {
        public static string CleanHtmlTags(this string source)
        {
            var array = new char[source.Length];
            var arrayIndex = 0;
            var inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string CleanInvalidChars(this string source)
        {
            source = source.Replace("`", "'");
            source = source.Replace("^", "'");
            source = source.Replace("…", ".");
            source = source.Replace("ˆ", "'");
            source = source.Replace("'", "'");
            source = source.Replace("'", "'");
            source = source.Replace("'", "'");
            source = source.Replace("\r\n", string.Empty);
            source = source.Replace("\r", string.Empty);
            source = source.Replace("\n", string.Empty);
            source = source.Replace("\t", string.Empty);
            source = source.Replace("~", string.Empty);
            source = source.Replace("€", string.Empty);

            return source;
        }

        public static string ToPhoneNumber(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            text = new string(text.Where(char.IsDigit).ToArray());
            if (text.Length > 11) return text.Substring(text.Length - 12);
            if (text.Length > 10) return text.Substring(text.Length - 11);
            if (text.Length > 9) return text.Substring(text.Length - 10);

            return string.Empty;
        }

        public static bool IsMobilePhoneNumber(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            text = new string(text.Where(char.IsDigit).ToArray());
            if (text.Length == 10 && text.StartsWith("5")) return true;
            if (text.Length == 11 && text.StartsWith("05")) return true;
            if (text.Length == 12 && text.StartsWith("905")) return true;

            return false;
        }
    }
}