using NoNameDev.CSharpCommon.Utils.Resources;

namespace NoNameDev.CSharpCommon.Extensions {

    public static class BooleanExtensions {

        public static string ToLocalizedString(this bool value, BooleanFormattingType formattingType) {
            return ResourceUtils.GetString(typeof(BooleanExtensions), value ? "Yes" : "No");
        }
    }
}