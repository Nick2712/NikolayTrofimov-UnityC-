using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class SaveDataRepository
    {
        private readonly IData<List<SaveData>> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            //if(Application.platform == RuntimePlatform.WebGLPlayer)
            //{
            //    _data = new PlayerPrefsData();
            //}
            //else
            //{
                _data = new JsonData<List<SaveData>>();
            //}
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(PlayerBase player, List<InteractiveObject> interactiveObjects)
        {
            if(!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SaveData
            {
                Position = player.transform.position,
                Name = "Nikolay",
                IsEnabled = true
            };
            List<SaveData> saveDatas = new List<SaveData>();
            saveDatas.Add(savePlayer);
            for(int i = 0; i < interactiveObjects.Count; i++)
            {
                savePlayer = new SaveData
                {
                    Position = interactiveObjects[i].transform.position,
                    Name = interactiveObjects[i].name,
                    IsEnabled = interactiveObjects[i].isActiveAndEnabled
                };
                saveDatas.Add(savePlayer);
            }

            _data.Save(saveDatas, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player, List<InteractiveObject> interactiveObjects)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            if (newPlayer.Count > 0)
            {
                player.transform.position = newPlayer[0].Position;
                player.name = newPlayer[0].Name;
                player.gameObject.SetActive(newPlayer[0].IsEnabled);
                Debug.Log(newPlayer[0]);

                for (int i = 1; i < newPlayer.Count; i++)
                {
                    interactiveObjects[i - 1].transform.position = newPlayer[i].Position;
                    interactiveObjects[i - 1].name = newPlayer[i].Name;
                    interactiveObjects[i - 1].IsInteractable = newPlayer[i].IsEnabled;
                    //interactiveObjects[i - 1].gameObject.SetActive(newPlayer[i].IsEnabled);
                    Debug.Log(newPlayer[i]);
                }
            }


            Debug.Log(newPlayer);
        }
    }
}