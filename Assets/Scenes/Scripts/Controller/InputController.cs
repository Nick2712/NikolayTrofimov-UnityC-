using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly List<InteractiveObject> _listInteractiveObject;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        public InputController(PlayerBase player, List<InteractiveObject> listInteractiveObject)
        {
            _playerBase = player;
            _listInteractiveObject = listInteractiveObject;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute(float timeDeltatime)
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer)) _saveDataRepository.Save(_playerBase, _listInteractiveObject);
            if (Input.GetKeyDown(_loadPlayer)) _saveDataRepository.Load(_playerBase, _listInteractiveObject);
        }
    }
}