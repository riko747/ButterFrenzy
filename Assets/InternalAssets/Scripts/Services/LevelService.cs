using InternalAssets.Scripts.Level;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    internal interface ILevelService
    {
        LevelData LoadLevel(int index);
    }
    public class LevelService : MonoBehaviour, ILevelService
    {
        [Inject] private IResourcesService _resourcesService;

        public LevelData LoadLevel(int index) => Instantiate(_resourcesService.LoadLevel(index)).GetComponent<LevelData>();
    }
}
