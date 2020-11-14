namespace NikolayTrofimov_Game
{
    public sealed class DisplayingInformation
    {
        private readonly PlayerController _playerController;
        private readonly IDisplayingInformation[] _displayingInformation;

        public DisplayingInformation(PlayerController playerController)
        {
            _playerController = playerController;
            _displayingInformation = new IDisplayingInformation[]
            {
                new DisplaySpeedChangeInformation(_playerController),
                new DisplayInvulnerabilityInformation(_playerController)
            };
        }

        public IDisplayingInformation[] GetDisplayingInformation()
        {
            return _displayingInformation;
        }
    }
}