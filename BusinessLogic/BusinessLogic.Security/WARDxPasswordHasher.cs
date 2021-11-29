using BusinessLogic.Interface;
using System;
using System.Security.Cryptography;

namespace BusinessLogic.Security
{
    public class WARDxPasswordHasher : IWARDxPasswordHasher
    {
        private byte[] salt;
        private readonly int hashSize = 20;
        private readonly int saltSize = 16;

        public string Hash(string password, int iterations)
        {
            // create salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);

            // create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(hashSize);

            // combine salt and hash
            var hashBytes = new byte[saltSize + hashSize];
            // copy salt to hashBytes
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            // copy hash to hashBytes
            Array.Copy(hash, 0, hashBytes, saltSize, hashSize);

            // convert to base64 string
            var base64Hash = Convert.ToBase64String(hashBytes);

            // format hash with extra information
            return string.Format("$HWMS06${0}${1}", iterations, base64Hash);
        }

        public string Hash(string password)
        {
            return Hash(password, 10000);
        }

        public bool IsHashSupported(string passwordHash)
        {
            return passwordHash.Contains("$HWMS06$");
        }

        public bool Verify(string password, string passwordHash)
        {
            // check hash
            if (IsHashSupported(passwordHash) == false)
            {
                throw new NotSupportedException("The password hash is not supported!");
            }

            // extract iteration and Base64 string
            var splitHashString = passwordHash.Replace("$HWMS06$", "").Split('$');
            var iterations = int.Parse(splitHashString[0]);
            var base64Hash = splitHashString[1];

            // get hashbytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // get salt
            var salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            // create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(hashSize);

            // get result
            for (var i = 0; i < hashSize; i++)
            {
                if (hashBytes[i + saltSize] != hash[i])
                {
                    // a byte in the array does not match
                    return false;
                }
            }
            return true;
        }
    }
}
