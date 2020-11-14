using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class EffectSpeedUp : IGoodEffectable
    {
        private EffectData _effectData;

        public EffectSpeedUp(EffectData effectData)
        {
            _effectData = effectData;
        }

        public void Effect(PlayerController player, GameController gameController)
        {
            player.SpeedUpEffect(Random.Range(_effectData.SpeedUpMinTime, _effectData.SpeedUpMaxTime));
            Debug.Log("сработало ускорение");
        }
    }
}