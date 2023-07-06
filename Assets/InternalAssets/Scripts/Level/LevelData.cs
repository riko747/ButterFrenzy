using UnityEngine;

namespace InternalAssets.Scripts.Level
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private Transform levelStartTransform;

        public Transform LevelStartTransform => levelStartTransform;
    }
}
