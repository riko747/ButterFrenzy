using Cinemachine;
using InternalAssets.Scripts.Other;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class GameService : MonoBehaviour
    {
        [Inject] private ILevelService _levelService;
        [Inject] private IResourcesService _resourcesService;

        [SerializeField] private CinemachineVirtualCamera cineMachineVirtualCamera;
        
        private void Start() => StartGame();

        private void StartGame()
        {
            var level = _levelService.LoadLevel(PlayerPrefs.HasKey(Constants.LastLevel)
                ? PlayerPrefs.GetInt(Constants.LastLevel)
                : 0);
            
            var player = Instantiate(_resourcesService.LoadPlayer(), level.PlayerStartPosition, Quaternion.identity);
            cineMachineVirtualCamera.Follow = player.transform;
            cineMachineVirtualCamera.LookAt = player.transform;
            cineMachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 4, -5);
        }
    }
}
