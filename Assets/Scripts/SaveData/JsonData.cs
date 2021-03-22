using System.IO;
using UnityEngine;

namespace LabirintSpace
    {
    public class JsonData<T> : IData<T>
        {

        public void Save(T data, string path = null)
            {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.CryptoXOR(str)); //С шифрованием
            //File.WriteAllText(path, str); //Без шифрования

            }
        public T Load(string path = null)
            {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str)); //С шифрованием
            //return JsonUtility.FromJson<T>(str); //Без шифрования
            }
        }
    }