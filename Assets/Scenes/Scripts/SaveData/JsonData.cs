using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public class JsonData<T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, str);
            // File.WriteAllText(path, str);
        }

        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(str);
            // return JsonUtility.FromJson<T>(str);
        }
    }
}