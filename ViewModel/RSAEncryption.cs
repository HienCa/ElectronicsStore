using System;
using System.Security.Cryptography;
using System.Text;

namespace ElectronicsStore.ViewModel
{
    public class RSAEncryption
    {
        private RSACryptoServiceProvider _rsa;

        public RSAEncryption()
        {
            // Initialize a new instance of the RSACryptoServiceProvider class with a key size of 2048 bits
            _rsa = new RSACryptoServiceProvider(2048);
        }

        public string Encrypt(string plainText)
        {
            byte[] encryptedData;
            try
            {
                // Convert the plain text to bytes and encrypt using the public key
                encryptedData = _rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
            }
            catch (Exception ex)
            {
                // Handle encryption errors here
                throw new Exception("Error encrypting data: " + ex.Message);
            }

            // Convert the encrypted bytes to base64 string
            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string cipherText)
        {
            byte[] decryptedData;
            try
            {
                // Convert the cipher text to bytes and decrypt using the private key
                decryptedData = _rsa.Decrypt(Convert.FromBase64String(cipherText), false);
            }
            catch (Exception ex)
            {
                // Handle decryption errors here
                throw new Exception("Error decrypting data: " + ex.Message);
            }

            // Convert the decrypted bytes to plain text
            return Encoding.UTF8.GetString(decryptedData);
        }

        public string GetPublicKeyXml()
        {
            // Export the public key in XML format
            return _rsa.ToXmlString(false);
        }
    }
}
