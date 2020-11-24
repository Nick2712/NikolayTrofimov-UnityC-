using UnityEngine;


namespace NikolayTrofimov_Game
{
    [CreateAssetMenu(fileName = "EffectData", menuName = "EffectData")]
    public sealed class EffectData : ScriptableObject
    {
        [Tooltip("Минимальное время неуязвимости")] [Range(1.0f, 7.0f)] 
        public float InvulnerabilityMinTime = 5.0f;
        [Tooltip("Максимальное время неуязвимости")] [Range(8.0f, 15.0f)] 
        public float InvulnerabilityMaxTime = 10.0f;
        [Space(10)]
        [Tooltip("Минимальное время ускорения")] [Range(1.0f, 7.0f)] 
        public float SpeedUpMinTime = 5.0f;
        [Tooltip("Максимальное время ускорения")] [Range(8.0f, 15.0f)] 
        public float SpeedUpMaxTime = 10.0f;
        [Space(10)]
        [Tooltip("Минимальное время замедления")] [Range(1.0f, 7.0f)] 
        public float SlowingMinTime = 5.0f;
        [Tooltip("Максимальное время замедления")] [Range(8.0f, 15.0f)] 
        public float SlowingMaxTime = 10.0f;
        [Space(10)]
        [Tooltip("Обычная скорость игрока")] [Range(2.0f, 7.0f)] 
        public float NormalPlayerSpeed = 3.0f;
        [Tooltip("Скорость ускоренного игрока")] [Range(8.0f, 15.0f)] 
        public float SpeedUpPlayerSpeed = 10.0f;
        [Tooltip("Скорость замедленного игрока")] [Range(1.0f, 3.0f)] 
        public float SlowingPlayerSpeed = 1.0f;
        [Space(10)]
        [Tooltip("Максимальное количество получаемых очков")] [Range(1, 9)] 
        public int MinScoreCountGoodEffect = 5;
        [Tooltip("Минимальное количество получаемых очков")] [Range(10, 20)] 
        public int MaxScoreCountGoodEffect = 10;
    }
}