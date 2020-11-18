using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public class JsonData<T> : IData<T>
    {
        private List<T> _saveData = new List<T>();
        private string _savingString;

        public void Save(T data, string path = null)
        {
            //var str = JsonUtility.ToJson(data);
            var str = JsonUtility.ToJson(_savingString);
            File.WriteAllText(path, str);
        }

        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(str);
        }

        public void FillDataList(T obj)
        {
            _saveData.Add(obj);
        }

        public void MakeString()
        {
            foreach(T o in _saveData)
            {
                _savingString += o.ToString();
                _savingString += "\n";
            }
        }
    }
}