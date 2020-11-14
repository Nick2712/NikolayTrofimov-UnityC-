namespace NikolayTrofimov_Game
{
    public sealed class CheckForWinGame
    {
        private readonly GameController _gameController;

        public CheckForWinGame(GameController gameController)
        {
            _gameController = gameController;
        }

        public bool GameIsComplete()
        {
            return _gameController.GoodBonusesCount <= 0;
        }
    }
}