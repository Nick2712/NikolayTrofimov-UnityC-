using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NikolayTrofimov_Game
{
	public sealed class Radar : IExecute
	{
		private readonly Transform _playerPos; // Позиция главного героя
		private readonly float _mapScale = 2;
		private readonly List<RadarObject> _radObjects = new List<RadarObject>();
		private GameObject _radarGameObject;
		private GameController _gameController;


        public Radar(PlayerBase player, GameObject radar, GameController gameController)
        {
			_playerPos = player.transform;
			_radarGameObject = radar;
			_gameController = gameController;
		}

		//private void Start()
		//{
		//	_playerPos = Camera.main.transform;
		//}
		
		public void RegisterRadarObject(GameObject o, Image i)
		{
			Image image = _gameController.InstantiateImage(_radarGameObject, i);
			//Image image = _radarGameObject.AddComponent<Image>();
			//_radarGameObject.AddComponent<Image>();
			//Instantiate(i);
			_radObjects.Add(new RadarObject { Owner = o, Icon = image });
		}
		
		public void RemoveRadarObject(GameObject o)
		{
			List<RadarObject> newList = new List<RadarObject>();
			foreach (RadarObject t in _radObjects)
			{
				if (t.Owner == o)
				{
					_gameController.DestroyImage(t.Icon);
					//Destroy(t.Icon);
					continue;
				}
				newList.Add(t);
			}
			_radObjects.RemoveRange(0, _radObjects.Count);
			_radObjects.AddRange(newList);
		}
		
		private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
		{
			foreach (RadarObject radObject in _radObjects)
			{
                Vector3 radarPos = (radObject.Owner.transform.position -
                                    _playerPos.position) * _mapScale;
                //float distToObject = Vector3.Distance(_playerPos.position,
                //                         radObject.Owner.transform.position) * _mapScale;
                //float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg -
                //               270 - _playerPos.eulerAngles.y;
                //radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
                //radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
                //radObject.Icon.transform.SetParent(_radarGameObject.transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x,
              radarPos.z, 0) + _radarGameObject.transform.position;

                
            }
		}
		
		//private void Update()
		//{
		//	if (Time.frameCount % 2 == 0)
		//	{
		//		DrawRadarDots();
		//	}
		//}

        public void Execute(float timeDeltatime)
        {
			if (Time.frameCount % 2 == 0)
			{
				DrawRadarDots();
			}
		}
    }
	
	public sealed class RadarObject
	{
		public Image Icon;
		public GameObject Owner;
	}
}