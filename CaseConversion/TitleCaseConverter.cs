using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.CaseConversion {
    public static class TitleCaseConverter
    {
        public static string ToTitleCase(string text) {
            if (text == null) {
                return null;
            }

            // This is the array of words that should be output in lower case
            string[] lowerCaseWords = new string[] {
        "a", "an", "and", "as", "at", "but", "by", "en", "for", "if", "in",
        "nor", "of", "on", "or", "the", "to", "v", "v.", "vs", "vs.", "via" };

            // Split the title on white space
            string[] parts = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Process each part of the title (recursively if necessary to split further)
            List<string> b = new List<string>();
            for (int i = 0; i < parts.Length; i++) {
                char previousCharacter = (i > 0 ? parts[i - 1][parts[i - 1].Length - 1] : ' ');
                string processedPart = ProcessTitlePart(parts, i, previousCharacter, lowerCaseWords);
                if (!string.IsNullOrWhiteSpace(processedPart)) {
                    b.Add(processedPart);
                }
            }

            // Re-join the title with spaces
            return string.Join(" ", b.ToArray());
        }

        private static string ProcessTitlePart(string[] parts, int index, char previousCharacter, string[] lowerCaseWords) {
            string result = parts[index];

            if (index > 0 &&
                index < (parts.Length - 1) &&
                previousCharacter != ':' &&
                previousCharacter != '-' &&
                Array.IndexOf(lowerCaseWords, parts[index].ToLower()) != -1) {
                // It's a small word (but not the first or last or after a colon or dash) and should be returned in lower-case
                result = parts[index].ToLowerInvariant();
            } else if (parts[index].Length == 1) {
                // It's just one letter, capitalize it
                result = parts[index].ToUpperInvariant();
            } else if (parts[index].StartsWith("/")) {
                // It's a Unix style path and should be returned in lower-case
                result = parts[index].ToLowerInvariant();
            } else if (parts[index].Contains("-")) {
                // It contains a hyphen and so each sub-part should be processed (e.g. Step-by-Step)
                result = ProcessTitleSubParts(parts[index], '-', previousCharacter, lowerCaseWords);
            } else if (parts[index].Contains("/")) {
                // It contains a forward slash and so each sub-part should be processed (e.g. Could/Should)
                result = ProcessTitleSubParts(parts[index], '/', previousCharacter, lowerCaseWords);
            } else {
                // The first letter should be capitalized (ignoring things like an opening parenthesis)
                for (int j = 0; j < parts[index].Length; j++) {
                    if (char.IsLetter(parts[index][j])) {
                        result = (j > 0 ? parts[index].Substring(0, j) : "") + parts[index][j].ToString().ToUpperInvariant() + parts[index].Substring(j + 1).ToLowerInvariant();
                        break;
                    }
                }
            }

            return result;
        }

        private static string ProcessTitleSubParts(string part, char separator, char previousCharacter, string[] lowerCaseWords) {
            string[] subParts = part.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < subParts.Length; j++) {
                char subPreviousCharacter;
                if (j > 0) {
                    subPreviousCharacter = subParts[j - 1][subParts[j - 1].Length - 1];
                } else {
                    subPreviousCharacter = previousCharacter;
                }
                subParts[j] = ProcessTitlePart(subParts, j, subPreviousCharacter, lowerCaseWords);
            }
            return string.Join(separator.ToString(), subParts);
        }
    }
}
