using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.Randomization
{
    public static class RandomUtils {
        public static readonly Random _random = new Random();

        public static int Next() {
            lock (_random) {
                return _random.Next();
            }
        }

        public static int Next(int maxValue) {
            lock (_random) {
                return _random.Next(maxValue);
            }
        }

        public static T RandomElement<T>(IEnumerable<T> values) {
            lock (_random) {
                return (T)values.ElementAt(_random.Next(values.Count()));
            }
        }

        public static string RandomEmail(int length) {
            return $"{RandomLowercaseAlphaString((length - 4) / 2)}@{RandomLowercaseAlphaString((length - 4) / 2)}.com";
        }

        public static string RandomPhoneNumber() {
            return $"{RandomNumericString(3)}-{RandomNumericString(3)}-{RandomNumericString(4)}";
        }

        public static T RandomEnum<T>() {
            Array values = Enum.GetValues(typeof(T));
            lock (_random) {
                return (T)values.GetValue(_random.Next(values.Length));
            }
        }

        public static int RandomInt(int min, int max) {
            lock (_random) {
                return _random.Next(min, max + 1);
            }
        }

        public static string RandomLowercaseAlphaString(int length) {
            return RandomString(length, "abcdefghijklmnopqrstuvwxyz");
        }

        public static string RandomNumericString(int length) {
            return RandomString(length, "0123456789");
        }

        public static string RandomString(int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789") {
            var stringChars = new char[length];
            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
    }
}