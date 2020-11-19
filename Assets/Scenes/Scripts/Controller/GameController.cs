using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NikolayTrofimov_Game
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] private EffectData _effectData;
        [SerializeField] private GameObject _miniMapGameObject;
        [SerializeField] private GameObject _radarGameObject;
        public PlayerType PlayerType = PlayerType.Ball;
        private List<IExecute> _listFixedUpdateObjects;
        //private ListExecuteObject _listFixedUpdateObjects;
        private List<IExecute> _listUpdateObjects;
        private List<IExecute> _listLateUpdateObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private PlayerController _playerController;
        private EffectManager _effectManager;
        private DisplayingInformation _displayingInformation;
        private DisplayStartGame _displayStartGame;
        private DisplayWinGame _displayWinGame;
        private CheckForWinGame _checkForWinGame;

        private MiniMap _miniMap;
        private Radar _radar;

        private Reference _reference;

        public int GoodBonusesCount { get; private set; }
        public int CountBonuses { get; private set; }

        private DisplayingInformationStruct _displayingInformationStruct;

        private void Awake()
        {
            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            _radar = new Radar(player, _radarGameObject, this);

            //_listFixedUpdateObjects = new ListExecuteObject();
            _listFixedUpdateObjects = new List<IExecute>();
            var interactiveObjects = UnityEngine.Object.FindObjectsOfType<InteractiveObject>();
            for (var i = 0; i < interactiveObjects.Length; i++)
            {
                interactiveObjects[i].gameObject.AddComponent<RadarObj>().SetRadar(_radar);
                if (interactiveObjects[i] is IExecute interactiveObject)
                {
                    _listFixedUpdateObjects.Add(interactiveObject);
                }
            }

            

            
            _listLateUpdateObjects = new List<IExecute>();
            _listUpdateObjects = new List<IExecute>();

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _listLateUpdateObjects.Add(_cameraController);

            _miniMap = new MiniMap(_miniMapGameObject);
            _listLateUpdateObjects.Add(_miniMap);

            _listUpdateObjects.Add(_radar);

            _playerController = new PlayerController(player, _effectData);
            _listUpdateObjects.Add(_playerController);

            _effectManager = new EffectManager(_playerController, _effectData, this);

            _displayingInformation = new DisplayingInformation(_playerController);

            _checkForWinGame = new CheckForWinGame(this);

            //с этим управление в билде не работает
            //if (Application.platform == RuntimePlatform.WindowsEditor)
            //{
            //    _inputController = new InputController(player);
            //    _interactiveObject.AddExecuteObject(_inputController);
            //}

            _inputController = new InputController(player, _listFixedUpdateObjects);
            _listFixedUpdateObjects.Add(_inputController);


            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            _displayStartGame = new DisplayStartGame(_reference.EndGame);
            _displayWinGame = new DisplayWinGame(_reference.EndGame, this);

            foreach (var o in _listFixedUpdateObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.SetEffectManager(_effectManager);

                    //я избавился от всех событий, эти строки кода стали не нужны
                    //badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    //badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.SetEffectManager(_effectManager);
                    GoodBonusesCount++;
                    //goodBonus.OnPointChange += AddBonuse;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
            _reference.StartButton.onClick.AddListener(StartGame);
            _displayStartGame.StartGame();
            Time.timeScale = 0.0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void StartGame()
        {
            _reference.EndGame.gameObject.SetActive(false);
            _reference.StartButton.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void WinGame()
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            _reference.EndGame.SetActive(true);
            _displayWinGame.WinGame();
        }

        public void CaughtPlayer(string name, Color color)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            _reference.EndGame.SetActive(true);
            _displayEndGame.GameOver(name, color);
        }

        public void AddBonuse(int value)
        {
            CountBonuses += value;
            _displayBonuses.Display(CountBonuses);
            GoodBonusesCount--;
            if (_checkForWinGame.GameIsComplete()) WinGame();
            Debug.Log(CountBonuses);
        }

        public Image InstantiateImage(GameObject parent, Image prefab)
        {
            var newImage = Instantiate(prefab);
            newImage.transform.SetParent(parent.transform, false);
            return newImage;
        }

        public void DestroyImage(Image destroingImage)
        {
            Destroy(destroingImage);
        }

        private void Update()
        {
            for (int i = 0; i < _listUpdateObjects.Count; i++)
            {
                _listUpdateObjects[i].Execute(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            for (var i = 0; i < _listFixedUpdateObjects.Count; i++)
            {
                var interactiveObject = _listFixedUpdateObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute(Time.fixedDeltaTime);
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < _listLateUpdateObjects.Count; i++)
            {
                _listLateUpdateObjects[i].Execute(Time.deltaTime);
            }
        }

        private void OnGUI()
        {
            for(int i = 0; i < _displayingInformation.GetDisplayingInformation().Length; i++)
            {
                if(_displayingInformation.GetDisplayingInformation()[i].DisplayInformation(
                    out _displayingInformationStruct))
                {
                    GUI.Box(_displayingInformationStruct.Position, _displayingInformationStruct.Text);
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _listFixedUpdateObjects)
            {
                if (o is BadBonus badBonus)
                {
                    //badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    //badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    //goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }
    }
}