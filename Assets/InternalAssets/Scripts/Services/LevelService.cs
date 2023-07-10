using InternalAssets.Scripts.Level;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    internal interface ILevelService
    {
        LevelData LoadLevel(int index);
        int CurrentLevel { get; set; }
    }
    public class LevelService : MonoBehaviour, ILevelService
    {
        [Inject] private IGameService _gameService;
        [Inject] private IResourcesService _resourcesService;

        private LevelData _currentLevelData;
        
        public int CurrentLevel { get; set; }

        public LevelData LoadLevel(int index)
        {
            CurrentLevel = index;
            _currentLevelData = _gameService.Instantiator.InstantiatePrefab(_resourcesService.LoadLevel(index)).GetComponent<LevelData>();
            return _currentLevelData;
        }
    }
}
