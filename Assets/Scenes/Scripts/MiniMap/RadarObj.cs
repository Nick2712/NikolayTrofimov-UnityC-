using UnityEngine;
using UnityEngine.UI;

namespace NikolayTrofimov_Game
{
	public sealed class RadarObj : MonoBehaviour
	{
		private Image _ico;
		private Radar _radar;

        private void Awake()
        {
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
		}

        private void OnValidate()
        {
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
        }

        private void OnDisable()
		{
			_radar.RemoveRadarObject(gameObject);
		}

		//private void OnEnable()
		//{
		//	_radar.RegisterRadarObject(gameObject, _ico);
		//}

		public void SetRadar(Radar radar)
        {
			_radar = radar;
			_radar.RegisterRadarObject(gameObject, _ico);
		}
	}
}