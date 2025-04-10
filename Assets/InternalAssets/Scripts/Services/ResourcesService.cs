using InternalAssets.Scripts.Other;
using Unity.VisualScripting;
using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    public class ResourcesService : IResourcesService
    {
        public bool IsLevelExists(int index)
        {
            var level = Resources.Load(Constants.ResourcesLevelLocation + index).GameObject();
            return level;
        }
        public GameObject LoadLevel(int index) => Resources.Load(Constants.ResourcesLevelLocation + index).GameObject();

        public GameObject LoadPlayer() => Resources.Load(Constants.ResourcesPlayerLocation).GameObject();
    }
}
