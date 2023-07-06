using Unity.VisualScripting;
using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    internal interface IResourcesService
    {
        GameObject LoadLevel(int index);
    }
    public class ResourcesService : MonoBehaviour, IResourcesService
    {
        public GameObject LoadLevel(int index) => Resources.Load("Prefabs/Levels/Level" + index).GameObject();
    }
}
