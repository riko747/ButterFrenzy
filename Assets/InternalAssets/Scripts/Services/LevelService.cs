using InternalAssets.Scripts.Level;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    internal interface ILevelService
    {
        LevelData LoadLevel(int index);
        public int CurrentLevel { get; set; }
    }
    public class LevelService : MonoBehaviour, ILevelService
    {
        [Inject] private IGameService _gameService;
        [Inject] private IResourcesService _resourcesService;

        public int CurrentLevel { get; set; }

        public LevelData LoadLevel(int index)
        {
            CurrentLevel = index;
            return _gameService.Instantiator.InstantiatePrefab(_resourcesService.LoadLevel(index)).GetComponent<LevelData>();
        }
    }
}
