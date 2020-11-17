using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public class StreamData : IData<SaveData>
    {
        public void Save(SaveData data, string path = null)
        {
            if (path == null) return;
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(data.Name);
                sw.WriteLine(data.Position.X);
                sw.WriteLine(data.Position.Y);
                sw.WriteLine(data.Position.Z);
                sw.WriteLine(data.IsEnabled);
            }
        }

        public SaveData Load(string path = null)
        {
            var result = new SaveData();

            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    result.Name = sr.ReadLine();
                    if (float.TryParse(sr.ReadLine(), out float valueX)) result.Position.X = valueX;
                    if (float.TryParse(sr.ReadLine(), out float valueY)) result.Position.Y = valueY;
                    if (float.TryParse(sr.ReadLine(), out float valueZ)) result.Position.Z = valueZ;
                    if (bool.TryParse(sr.ReadLine(), out bool valueIsEnabled)) result.IsEnabled = valueIsEnabled;
                }
            }
            return result;
        }
    }
}