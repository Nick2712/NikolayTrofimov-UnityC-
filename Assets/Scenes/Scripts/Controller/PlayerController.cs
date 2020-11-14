namespace NikolayTrofimov_Game
{
    public sealed class PlayerController : IExecute
    {
        private readonly PlayerBase _player;
        private readonly EffectData _effectData;
        public float NormalSpeed { get; private set; }
        public float HighSpeed { get; private set; }
        public float LowSpeed { get; private set; }
        public float ChangingSpeedTime { get; private set; } = 0.0f;
        public float InvulnerabilityTime { get; private set; } = 0.0f;
        public float CurrentPlayerSpeed { get; private set; }
        
        public PlayerController(PlayerBase player, EffectData effectData)
        {
            _player = player;
            _effectData = effectData;
            NormalSpeed = _effectData.NormalPlayerSpeed;
            player.Speed = _effectData.NormalPlayerSpeed;
            CurrentPlayerSpeed = player.Speed;
            HighSpeed = _effectData.SpeedUpPlayerSpeed;
            LowSpeed = _effectData.SlowingPlayerSpeed;
        }

        public void Execute(float timeDeltatime)
        {
            if(ChangingSpeedTime > 0.0f)
            {
                ChangingSpeedTime -= timeDeltatime;
                if (ChangingSpeedTime < 0.0f)
                {
                    ChangingSpeedTime = 0.0f;
                    _player.Speed = NormalSpeed;
                    CurrentPlayerSpeed = NormalSpeed;
                }
            }

            if(InvulnerabilityTime > 0.0f)
            {
                InvulnerabilityTime -= timeDeltatime;
                if (InvulnerabilityTime < 0.0f)
                {
                    InvulnerabilityTime = 0.0f;
                    _player.Invulnerability = false;
                }
            }
        }

        public void SpeedUpEffect(float timeActivity)
        {
            _player.Speed = HighSpeed;
            CurrentPlayerSpeed = HighSpeed;
            ChangingSpeedTime = timeActivity;
        }

        public void SpeedLowEffect(float timeActivity)
        {
            _player.Speed = LowSpeed;
            CurrentPlayerSpeed = LowSpeed;
            ChangingSpeedTime = timeActivity;
        }

        public void InvulnerabilityEffect(float timeActivity)
        {
            _player.Invulnerability = true;
            InvulnerabilityTime = timeActivity;
        }
    }
}