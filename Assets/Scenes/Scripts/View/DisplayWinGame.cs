using System;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_Game
{
    public sealed class DisplayWinGame
    {
        private Text _finishGameLabel;
        private GameController _gameController;

        public DisplayWinGame(GameObject startGame, GameController gameController)
        {
            _finishGameLabel = startGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
            _gameController = gameController;
        }

        public void WinGame()
        {
            _finishGameLabel.text = 
                $"Все бонусы собранны! Игра пройдена! Вы набрали {_gameController.CountBonuses} очков!";
        }
    }
}
