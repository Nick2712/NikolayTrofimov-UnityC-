
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NikolayTrofimov_Game
{
    public class Test : MonoBehaviour
    {
        void Start()
        {
            string str = "некоторая длинная строка. Количество символов 59. А длина строки 68.";
            int length = str.Length;
            int count = str.StringSimbolsCount();
            Debug.Log($"{count} {length}");

            List<int> someList = new List<int>(20);
            for (int i = 0; i < 20; i++)
            {
                someList.Add(UnityEngine.Random.Range(0, 10));
                Debug.Log(someList[i]);
            }
            Dictionary<int, int> calculatedSomeList = GetNumberOfRecuring(someList);
            foreach (KeyValuePair<int, int> someKey in calculatedSomeList)
            {
                Debug.Log($"елемент {someKey.Key} встречается {someKey.Value} раз");
            }
        }

        private Dictionary<T, int> GetNumberOfRecuring<T>(ICollection<T> list)
        {
            Dictionary<T, int> count = new Dictionary<T, int>();
            foreach (T val in list)
            {
                if (count.ContainsKey(val))
                {
                    count[val]++;
                }
                else
                {
                    count.Add(val, 1);
                }
            }
            return count;
        }
    }
}