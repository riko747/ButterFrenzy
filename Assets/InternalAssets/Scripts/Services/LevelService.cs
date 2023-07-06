using InternalAssets.Scripts.Level;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    internal interface ILevelService
    {
        void LoadLevel(int index);
        Vector3 StartPositionTransform { get; set; }
    }
    public class LevelService : MonoBehaviour, ILevelService
    {
        [Inject] private IResourcesService _resourcesService;

        public Vector3 StartPositionTransform { get; set; }
        
        public void LoadLevel(int index)
        {
            var level = Instantiate(_resourcesService.LoadLevel(index)).GetComponent<LevelData>();
            StartPositionTransform = level.LevelStartTransform.position;
        }
    }
}
