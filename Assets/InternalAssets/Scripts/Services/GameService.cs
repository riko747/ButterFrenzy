using Cinemachine;
using InternalAssets.Scripts.Level;
using InternalAssets.Scripts.Other;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class GameService : MonoBehaviour, IGameService
    {
        [Inject] private ILevelService _levelService;
        [Inject] private IResourcesService _resourcesService;
        [Inject] private IPlayerPrefsService _playerPrefsService;
        [Inject] public void Initialize(IInstantiator instantiator) => _instantiator = instantiator;

        [SerializeField] private CinemachineVirtualCamera cineMachineVirtualCamera;
        private IInstantiator _instantiator;

        public IInstantiator Instantiator => _instantiator;

        private void Start()
        {
            Application.targetFrameRate = 60;
            StartGame();
        }

        private void StartGame()
        {
            var level = CreateLevel();
            var player = CreatePlayer(level);
            SetupCamera(player);
        }

        private void SetupCamera(GameObject player)
        {
            cineMachineVirtualCamera.Follow = player.transform;
            cineMachineVirtualCamera.LookAt = player.transform;
            cineMachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 0, 1.5f);
        }

        private GameObject CreatePlayer(LevelData level) => _instantiator.InstantiatePrefab(_resourcesService.LoadPlayer(), level.PlayerStartPosition, Quaternion.identity, level.StartLevelTransform());

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
