using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class EffectSlowing : IBadEffectable
    {
        private EffectData _effectData;

        public EffectSlowing(EffectData effectData)
        {
            _effectData = effectData;
        }

        public void Effect(PlayerController player, GameController gameController, string name, Color color)
        {
            if(player.InvulnerabilityTime <= 0.0f)
            {
                player.SpeedLowEffect(Random.Range(_effectData.SpeedUpMinTime, _effectData.SpeedUpMaxTime));
                Debug.Log("сработало замедление");
            }
        }
    }
}