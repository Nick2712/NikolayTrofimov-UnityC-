using System;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_Game
{
    public sealed class DisplayStartGame
    {
        private Text _finishGameLabel;

        public DisplayStartGame(GameObject startGame)
        {
            _finishGameLabel = startGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        public void StartGame()
        {
            _finishGameLabel.text = "Соберите все Good Bonus'ы. Наберите как можно больше очков";
        }
    }
}
