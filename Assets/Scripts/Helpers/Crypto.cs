using System;

namespace LabirintSpace
    {
    public static class Crypto 
        {
        public static string CryptoXOR(string text, int key = 25)
            {
            var result = String.Empty;
            foreach(var symbol in text)
                {
                result += (char)(symbol ^ key);
                }
            return result;
            }
        }
    }