using System.Linq;

namespace Library.StorageServices
{
    public class CryptographyService
    {
        private const ushort SecretKey = 0x0088;
        public static string EncodeDecrypt(string str)
        {
            
            var ch = str.ToArray();
            var newStr = string.Empty;     
            foreach (var c in ch) 
                newStr += TopSecret(c, SecretKey);
            return newStr;
        }
        
        private static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey);
            return character;
        }
    }
}