using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Utils.Extensions {
    public static class MemberInfoExtensions {
        public static bool HasAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo.GetCustomAttributes(false).OfType<TAttribute>().Any();
        }

        public static TAttribute GetAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo.GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static List<TAttribute> GetAttributes<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo.GetCustomAttributes(false).OfType<TAttribute>().ToList();
        }
    }
}
