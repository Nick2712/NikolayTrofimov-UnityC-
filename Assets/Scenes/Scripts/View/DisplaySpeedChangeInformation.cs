using System;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class DisplaySpeedChangeInformation : IDisplayingInformation
    {
        private DisplayingInformationStruct _displayingInformationStruct;
        private readonly PlayerController _playerController;

        public DisplaySpeedChangeInformation(PlayerController playerController)
        {
            _playerController = playerController;
            _displayingInformationStruct.Position = new Rect(Screen.width - 110, 10, 100, 25);
        }

        public bool DisplayInformation(out DisplayingInformationStruct displayingInformationStruct)
        {
            if(_playerController.CurrentPlayerSpeed >= _playerController.HighSpeed)
            {
                _displayingInformationStruct.Text = 
                    $"ускорение {Math.Round(_playerController.ChangingSpeedTime)}";
                displayingInformationStruct = _displayingInformationStruct;
                return true;
            }
            else
            {
                if(_playerController.CurrentPlayerSpeed <= _playerController.LowSpeed)
                {
                    _displayingInformationStruct.Text = 
                        $"замедление { Math.Round(_playerController.ChangingSpeedTime)}";
                    displayingInformationStruct = _displayingInformationStruct;
                    return true;
                }
            }
            displayingInformationStruct = _displayingInformationStruct;
            return false;
        }
    }
}