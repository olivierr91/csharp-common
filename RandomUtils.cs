﻿using System;
using System.Collections.Generic;

namespace Common.Utils {
    public static class RandomUtils
    {
        public static readonly Random _random = new Random();

        public static string RandomString(int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789") {
            var stringChars = new char[length];
            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }
            return new String(stringChars);
        }

        public static int RandomInt(int min, int max) {
            return _random.Next(min, max + 1);
        }

        public static string RandomLowercaseAlphaString(int length) {
            return RandomString(length, "abcdefghijklmnopqrstuvwxyz");
        }

        public static string RandomNumericString(int length) {
            return RandomString(length, "0123456789");
        }

        public static string RandomEmail(int length) {
            return $"{RandomLowercaseAlphaString((length - 4) / 2)}@{RandomLowercaseAlphaString((length - 4) / 2)}.com";
        }

        public static T RandomEnum<T>() {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(_random.Next(values.Length));
        }

        public static T RandomItem<T>(IList<T> values) {
            return (T)values[_random.Next(values.Count)];
        }
    }
}
