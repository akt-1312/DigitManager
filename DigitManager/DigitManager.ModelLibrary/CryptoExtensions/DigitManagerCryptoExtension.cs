using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DigitManager.ModelLibrary.CryptoExtensions
{
    public static class DigitManagerCryptoExtension
    {
        public static string EncryptPassword(this string passoword)
        {
            string EncryptionKey = DataProtectionPurposeStrings.PasswordCryptoKey;
            byte[] clearBytes = Encoding.Unicode.GetBytes(passoword);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    passoword = Convert.ToBase64String(ms.ToArray());
                }
            }
            return passoword;
        }

        public static string DecryptPassword(this string encryptedPassoword)
        {
            string EncryptionKey = DataProtectionPurposeStrings.PasswordCryptoKey;
            byte[] cipherBytes = Convert.FromBase64String(encryptedPassoword);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    encryptedPassoword = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return encryptedPassoword;
        }

    }
}
