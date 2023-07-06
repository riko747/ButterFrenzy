using InternalAssets.Scripts.Other;
using Unity.VisualScripting;
using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    internal interface IResourcesService
    {
        GameObject LoadLevel(int index);
        GameObject LoadPlayer();
    }
    public class ResourcesService : MonoBehaviour, IResourcesService
    {
        public GameObject LoadLevel(int index) => Resources.Load(Constants.ResourcesLevelLocation + index).GameObject();

        public GameObject LoadPlayer() => Resources.Load(Constants.ResourcesPlayerLocation).GameObject();
    }
}
