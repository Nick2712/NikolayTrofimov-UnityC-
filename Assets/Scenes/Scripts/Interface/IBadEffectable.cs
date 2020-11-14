using UnityEngine;


namespace NikolayTrofimov_Game
{
    public interface IBadEffectable
    {
        void Effect(PlayerController player, GameController gameController, string name, Color color);
    }
}