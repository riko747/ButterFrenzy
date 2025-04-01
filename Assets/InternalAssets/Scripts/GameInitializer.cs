using Cinemachine;
using InternalAssets.Scripts.Services;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts
{
    public class GameInitializer : MonoBehaviour
    {
        [Inject] private GameService _gameService;
        [Inject] private BonusService _bonusService;
        [Inject] private UIService _uiService;

        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        
        private void Start()
        {
            Application.targetFrameRate = 60;
            _gameService.Initialize();
            _gameService.SetupCamera(virtualCamera);
            
            _bonusService.Initialize();
        }
    }
}
