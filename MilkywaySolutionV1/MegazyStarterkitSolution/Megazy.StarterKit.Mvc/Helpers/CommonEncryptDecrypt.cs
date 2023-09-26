using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using Sk.StepUpSolution.SComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Megazy.StarterKit.Mvc.Helpers
{
    public class CommonEncryptDecrypt
    {

        // set password
        // public const string strPassword = "LetMeIn99$";

        // set permutations
        public const string strPermutation = "megazylibraengine";
        public const int bytePermutation1 = 0x19;
        public const int bytePermutation2 = 0x59;
        public const int bytePermutation3 = 0x17;
        public const int bytePermutation4 = 0x41;

        // encoding
        public static string Encrypt(string strData)
        {
            string ret = Base64UrlEncoder.Encode(Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData))));
            return ret;
            // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

        }


        // decoding
        public static string Decrypt(string strData)
        {
            string ret = Base64UrlEncoder.Decode(strData);
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(ret)));
            // reference https://msdn.microsoft.com/en-us/library/system.convert.frombase64string(v=vs.110).aspx

        }

        // encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);
            aes.Padding = PaddingMode.Zeros;

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);
            aes.Padding = PaddingMode.Zeros;
            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
        // reference
        // https://msdn.microsoft.com/en-us/library/system.security.cryptography(v=vs.110).aspx
        // https://msdn.microsoft.com/en-us/library/system.security.cryptography.cryptostream%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
        // https://msdn.microsoft.com/en-us/library/system.security.cryptography.rfc2898derivebytes(v=vs.110).aspx
        // https://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396

        //https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        public static byte[] ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                //StringBuilder builder = new StringBuilder();
                //for (int i = 0; i < bytes.Length; i++)
                //{
                //    builder.Append(bytes[i].ToString("x2"));
                //}
                //return builder.ToString();
            }
        }
        //public static string Sha256Hash(string rawData)
        //{
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        //        // Convert byte array to a string   
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}
        //public static string ComputeBase64urlencodeSha256Hash(string rawData)
        //{
        //   // Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(
        //    return Base64UrlEncoder.Encode(Sha256Hash(rawData));
        //}
        public static string ComputeCodeVerifier()
        {
            ////public static string GetRandomAlphaNumeric()
            ////{}
            //Random random = new Random();
            //var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            //    return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(57).ToArray());
            
            return  CryptoRandom.CreateUniqueId(32);
        }
        public static string ComputeBase64urlencode(string rawData)
        {
            return EncodeBase64URL(Encoding.UTF8.GetBytes(rawData));
        } public static string ComputeBase64(string rawData)
        {
            return Base64(Encoding.UTF8.GetBytes(rawData));
        }
        static string EncodeBase64URL(byte[] arg)
        {
          
            string s = Convert.ToBase64String(arg); // Regular base64 encoder
            s = s.Split('=')[0]; // Remove any trailing '='s
            s = s.Replace('+', '-'); // 62nd char of encoding
            s = s.Replace('/', '_'); // 63rd char of encoding
            return s;
        }
        static string Base64(byte[] arg)
        {
            return Convert.ToBase64String(arg);
        }

        // Compute the code_challenge parameter from the code_verifyer
        public static string MakeCodeChallenge(string codeVerifier)
        {
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                return EncodeBase64URL(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(codeVerifier)));
            }
        }

    }


}
