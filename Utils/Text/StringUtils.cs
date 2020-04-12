namespace CSharpCommon.Utils.Text {

    public static class StringUtils {

        public static string Minus(string str1, string str2) {
            for (int i = 0; i < str2.Length; i++) {
                var str2Part = str2.Substring(i);
                if (str1.StartsWith(str2Part)) {
                    return str1.Remove(0, str2Part.Length);
                }
            }
            return str1;
        }
    }
}