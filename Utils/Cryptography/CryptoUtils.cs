using System;
using System.Security.Cryptography;
using System.Text;

namespace NoNameDev.CSharpCommon.Utils.Cryptography {

    public class CryptoUtils {

        public static byte[] GetSalt() {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static (string salt, string hash) GetSaltedSHA256Hash(string text) {
            string salt = GetSaltString();
            string hash = GetSHA256Hash(text, salt);
            return (salt, hash);
        }

        public static string GetSaltString() {
            byte[] salt = GetSalt();
            return BitConverter.ToString(salt).Replace("-", "").ToLower();
        }

        public static string GetSHA256Hash(string text) {
            using (var sha256 = SHA256.Create()) {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string GetSHA256Hash(string text, string salt) {
            return GetSHA256Hash(text + salt);
        }
    }
}