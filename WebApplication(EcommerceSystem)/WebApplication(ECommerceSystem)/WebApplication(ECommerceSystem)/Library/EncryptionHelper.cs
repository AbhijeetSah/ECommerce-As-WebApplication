using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication_ECommerceSystem_.Library
{
    public class EncryptionHelper
    {
        public static class Global
        {
            public const String strPermutation = "KsfsNX09DS+ZMDPoT62xbQ1NjEZuuCbBMuu7/beHHKhdQq6O";
            public const Int32 bytePermutation1 = 0x19;
            public const Int32 bytePermutation2 = 0x59;
            public const Int32 bytePermutation3 = 0x17;
            public const Int32 bytePermutation4 = 0x41;
        }
        public static string Encrypt(string strData)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
        }

        private static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passBytes = new PasswordDeriveBytes(Global.strPermutation, new byte[] {
                Global.bytePermutation1,
                Global.bytePermutation2,
                Global.bytePermutation3,
                Global.bytePermutation4
            });
            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passBytes.GetBytes(aes.KeySize / 8);
            aes.IV = passBytes.GetBytes(aes.BlockSize / 8);
            CryptoStream cryptoStream = new CryptoStream(memstream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(strData, 0, strData.Length);
            cryptoStream.Close();
            return memstream.ToArray();



            //throw new NotImplementedException();
        }
    }
}