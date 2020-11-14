using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class EffectDeath : IBadEffectable
    {
        public void Effect(PlayerController player, GameController gameController, string name, Color color)
        {
            if (player.InvulnerabilityTime <= 0.0f)
            {
                Debug.Log("Смэээрт!");
                gameController.CaughtPlayer(name, color);
            }
        }
    }
}