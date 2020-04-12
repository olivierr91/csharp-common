using System.Numerics;

namespace CSharpCommon.Extensions.Numerics {

    public static class Vector2Extensions {

        public static Vector2 Fit(this Vector2 vector2, Vector2 other) {
            if (vector2.X <= other.X && vector2.Y <= other.Y) {
                return vector2;
            }
            if (vector2.Ratio() >= other.Ratio() && vector2.X > other.X) {
                return Vector2.Multiply(vector2, other.X / vector2.X);
            } else if (vector2.Ratio() <= other.Ratio() && vector2.Y > other.Y) {
                return Vector2.Multiply(vector2, other.Y / vector2.Y);
            }
            return vector2;
        }

        public static double Ratio(this Vector2 vector2) {
            return vector2.X / vector2.Y;
        }
    }
}