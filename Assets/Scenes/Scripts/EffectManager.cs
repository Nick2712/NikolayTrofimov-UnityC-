using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class EffectManager
    {
        private readonly PlayerController _playerController;
        private readonly EffectData _effectData;
        private readonly GameController _gameController;
        private readonly IGoodEffectable[] _goodEffects;
        private readonly IBadEffectable[] _badEffects;

        public EffectManager(PlayerController playerController, EffectData effectData, 
            GameController gameController)
        {
            _playerController = playerController;
            _effectData = effectData;
            _gameController = gameController;
            _goodEffects = new IGoodEffectable[]
            {
                new EffectInvulnerability(effectData),
                new EffectSpeedUp(effectData)
            };

            _badEffects = new IBadEffectable[]
            {
                new EffectSlowing(effectData),
                new EffectDeath()
            };
        }

        public void GoodEffecting()
        {
            _gameController.AddBonuse(
                Random.Range(_effectData.MinScoreCountGoodEffect, _effectData.MaxScortCountGoodEffect));
            _goodEffects[Random.Range(0, _goodEffects.Length)].Effect(_playerController, _gameController);
        }

        public void BadEffecting(string name, Color color)
        {
            _badEffects[Random.Range(0, _goodEffects.Length)].Effect(
                _playerController, _gameController, name, color);
        }
    }
}