using CSharpCommon.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCommon.Utils.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToLocalizedString(this bool value, BooleanFormattingType formattingType) {
            return ResourceUtils.FormatString(typeof(BooleanExtensions), value ? "Yes" : "No");
        }
    }
}
