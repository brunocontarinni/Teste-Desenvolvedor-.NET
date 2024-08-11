
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCreatorSpace
{
    class HashCreator
    {
        public static string GenerateHash(string stringToHashed)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHashed));
                
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }

                string hash = builder.ToString();
                return hash.Length > 10 ? hash.Substring(0, 10) : hash;
            }
        }

    }
}