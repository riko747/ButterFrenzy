using InternalAssets.Scripts.Level;
using InternalAssets.Scripts.Other;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class LevelService : ILevelService
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
