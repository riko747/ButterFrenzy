using InternalAssets.Scripts.Other;
using Unity.VisualScripting;
using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    internal interface IResourcesService
    {
        bool IsLevelExists(int index);
        GameObject LoadLevel(int index);
        GameObject LoadPlayer();
    }
    public class ResourcesService : MonoBehaviour, IResourcesService
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
