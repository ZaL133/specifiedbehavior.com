using System.Text.RegularExpressions;

namespace specifiedbehavior.web.Extensions
{
    public static class StringExtensions
    {
        public static string StripHtmlTags(this string input)
        {
            var stripped = Regex.Replace(input, "<.*?>", string.Empty);
            var replacedWhitespaceEntities = Regex.Replace(stripped, "&nbsp;", " ");
            return replacedWhitespaceEntities;

        }
    }
}
