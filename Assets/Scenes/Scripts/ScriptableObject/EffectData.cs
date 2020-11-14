using UnityEngine;


namespace NikolayTrofimov_Game
{
    [CreateAssetMenu(fileName = "EffectData", menuName = "EffectData")]
    public sealed class EffectData : ScriptableObject
    {
        public float InvulnerabilityMinTime = 5.0f;
        public float InvulnerabilityMaxTime = 10.0f;
        public float SpeedUpMinTime = 5.0f;
        public float SpeedUpMaxTime = 10.0f;
        public float SlowingMinTime = 5.0f;
        public float SlowingMaxTime = 10.0f;
        public float NormalPlayerSpeed = 3.0f;
        public float SpeedUpPlayerSpeed = 10.0f;
        public float SlowingPlayerSpeed = 1.0f;
        public int MinScoreCountGoodEffect = 5;
        public int MaxScortCountGoodEffect = 10;
    }
}