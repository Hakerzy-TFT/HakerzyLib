using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HakerzyLib.Security
{
    public class PasswordManager
    {
        public int GenerateSaltForPassowrd()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[4];
            rng.GetNonZeroBytes(saltBytes);
            return (((int)saltBytes[0]) << 24) + (((int)saltBytes[1]) << 16) + (((int)saltBytes[2]) << 8) + ((int)saltBytes[3]);
        }

        public byte[] ComputePasswordHash(string password, int salt)
        {
            byte[] saltBytes = new byte[4];
            saltBytes[0] = (byte)(salt >> 24);
            saltBytes[1] = (byte)(salt >> 16);
            saltBytes[2] = (byte)(salt >> 8);
            saltBytes[3] = (byte)(salt);

            byte[] passwordBytes = UTF8Encoding.UTF8.GetBytes(password);

            byte[] preHashed = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(passwordBytes, 0, preHashed, 0, passwordBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, preHashed, passwordBytes.Length, saltBytes.Length);

            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(preHashed);
        }

        public bool IsPassowrdValid(string passwordToValidate, int salt, byte[] correctPasswordHash)
        {
            byte[] hashedPassword = ComputePasswordHash(passwordToValidate, salt);
            return hashedPassword.SequenceEqual(correctPasswordHash);
        }
    }
}
