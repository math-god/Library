using System.Linq;

namespace Library.Service
{
    public class CryptographyService
    {
        private const ushort SecretKey = 0x0088;
        public static string EncodeDecrypt(string password)
        {
            var passwordCharsArray = password.ToArray();
            var encodeDecodePassword = string.Empty;     
            foreach (var passwordChar in passwordCharsArray) 
                encodeDecodePassword += MakeXorOperation(passwordChar, SecretKey);
            return encodeDecodePassword;
        }
        
        private static char MakeXorOperation(char passwordChar, ushort secretKey)
        {
            passwordChar = (char)(passwordChar ^ secretKey);
            return passwordChar;
        }
    }
}