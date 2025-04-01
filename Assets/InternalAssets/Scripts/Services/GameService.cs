using Cinemachine;
using InternalAssets.Scripts.Level;
using InternalAssets.Scripts.Other;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class GameService : IGameService
    {
        [Inject] private ILevelService _levelService;
        [Inject] private IResourcesService _resourcesService;
        [Inject] private IPlayerPrefsService _playerPrefsService;
        [Inject] public void Initialize(IInstantiator instantiator) => Instantiator = instantiator;

        public IInstantiator Instantiator { get; private set; }
        
        public GameObject Player { get; set; }

        public void Initialize()
        {
            var level = CreateLevel();
            Player = CreatePlayer(level);
        }

        public void SetupCamera(CinemachineVirtualCamera virtualCamera)
        {
            virtualCamera.Follow = Player.transform;
            virtualCamera.LookAt = Player.transform;
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 0, 1.5f);
        }

        private GameObject CreatePlayer(LevelData level) => Instantiator.InstantiatePrefab(_resourcesService.LoadPlayer(), level.PlayerStartPosition, Quaternion.identity, level.StartLevelTransform());

        private LevelData CreateLevel()
        {
            var level = _levelService.LoadLevel(PlayerPrefs.HasKey(Constants.LastLevel)
                ? PlayerPrefs.GetInt(Constants.LastLevel)
                : 0);
            return level;
        }

        public void EndGame(bool gameOver)
        {
            if (!gameOver && _resourcesService.IsLevelExists(_levelService.CurrentLevel + 1))
            {
                _levelService.CurrentLevel++;
                _playerPrefsService.SetPlayerPrefsValue(Constants.LastLevel, _levelService.CurrentLevel);
            }

            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
}
