using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public class JsonData<T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            if (data is List<SaveData> savedatas)
            {
                SaveData[] saveDatasArray = savedatas.ToArray();
                var str = JsonHelper.ToJson(saveDatasArray, true);
                File.WriteAllText(path, str);
            }
            else
            {
                var str = JsonUtility.ToJson(data);
                File.WriteAllText(path, str);
            }
            
            // File.WriteAllText(path, str);
        }

        public T Load(string path = null)
        {
            //T returnData = default;
            if (typeof(T) == typeof(List<SaveData>))
            {
                var str = File.ReadAllText(path);
                dynamic returnData = new List<SaveData>(JsonHelper.FromJson<SaveData>(str));
                return returnData;
            }
            else
            {
                var str = File.ReadAllText(path);
                return JsonUtility.FromJson<T>(str);
            }
            // return JsonUtility.FromJson<T>(str);
        }
    }
}