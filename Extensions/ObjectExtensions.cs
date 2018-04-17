using System.Linq;

namespace Common.Utils.Extensions {
    public static class ObjectExtensions
    {
        public static bool IsIn<T>(this T obj, params T[] args) {
            return args.Contains(obj);
        }

        public static bool IsNotIn<T>(this T obj, params T[] args) {
            return !args.Contains(obj);
        }
    }
}
