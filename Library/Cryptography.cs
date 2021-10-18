using System.Linq;

namespace Library
{
    public class Cryptography
    {
        private const ushort SecretKey = 0x0088;
        public static string EncodeDecrypt(string str)
        {
            
            var ch = str.ToArray(); //преобразуем строку в символы
            var newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c, SecretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }
        
        private static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); //Производим XOR операцию
            return character;
        }
    }
}