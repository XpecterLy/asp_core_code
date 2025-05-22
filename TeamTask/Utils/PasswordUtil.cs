using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamTask.Utils
{
    static class PasswordUtil
    {
        static public string GenerateHashPassword(string password)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return ByteArrayToString(tmpHash);
        }
        static public bool CompareHashPassword(string password, string hash)
        {
            var isSame = GenerateHashPassword(password) == hash;

            if (isSame)
                return true;
            else
                return false;
        }

        static private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
