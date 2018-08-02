using NoNameDev.CSharpCommon.Extensions.Text;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NoNameDev.CSharpCommon.Utils.Text {

    public static class RegExUtils {
        private const int MAX_TEXT_LENGTH_IN_EXCEPTION = 256;

        public static List<string> MatchAllSingleGroups(string pattern, string text, RegexOptions regexOptions = RegexOptions.None) {
            var results = new List<string>();
            var regex = new Regex(pattern, regexOptions);
            Match match = regex.Match(text);
            while (match.Success) {
                if (match.Success && match.Groups.Count == 2) {
                    results.Add(match.Groups[1].Value);
                }
                match = match.NextMatch();
            }
            return results;
        }

        public static List<string> MatchFirstGroup(string pattern, string text, RegexOptions regexOptions = RegexOptions.None) {
            var results = new List<string>();
            var regex = new Regex(pattern, regexOptions);
            Match match = regex.Match(text);
            if (match.Success && match.Groups.Count == 2) {
                foreach (Group group in match.Groups) {
                    results.Add(group.Value);
                }
            }
            return results;
        }

        public static string MatchSingleGroup(string pattern, string text, RegexOptions regexOptions = RegexOptions.None) {
            string result = MatchSingleGroupOrNull(pattern, text, regexOptions);
            if (result == null) {
                throw new ArgumentException($"Text '{text.TruncateWithEllipsis(MAX_TEXT_LENGTH_IN_EXCEPTION)}' cannot be matched to a single group using pattern '{pattern}'.");
            } else {
                return result;
            }
        }

        public static string MatchSingleGroupOrNull(string pattern, string text, RegexOptions regexOptions = RegexOptions.None) {
            if (text == null) { return null; }
            var regex = new Regex(pattern, regexOptions);
            Match match = regex.Match(text);
            if (match.Success && match.Groups.Count == 2) {
                return match.Groups[1].Value;
            } else {
                return null;
            }
        }
    }
}