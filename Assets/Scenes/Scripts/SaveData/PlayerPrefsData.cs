using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public class PlayerPrefsData : IData<SaveData>
    {
        public void Save(SaveData data, string path = null)
        {
            PlayerPrefs.SetString("Name", data.Name);
            PlayerPrefs.SetFloat("PosX", data.Position.X);
            PlayerPrefs.SetFloat("PosY", data.Position.Y);
            PlayerPrefs.SetFloat("PosZ", data.Position.Z);
            PlayerPrefs.SetString("IsEnable", data.IsEnabled.ToString());

            PlayerPrefs.Save();
        }

        public SaveData Load(string path = null)
        {
            var result = new SaveData();

            var key = "Name";
            if(PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = "PosX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }

            key = "PosY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Y = PlayerPrefs.GetFloat(key);
            }

            key = "PosZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Z = PlayerPrefs.GetFloat(key);
            }

            key = "IsEnable";
            if(PlayerPrefs.HasKey(key))
            {
                if (bool.TryParse(PlayerPrefs.GetString(key), out bool valueIsEnabled))
                    result.IsEnabled = valueIsEnabled;
            }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}