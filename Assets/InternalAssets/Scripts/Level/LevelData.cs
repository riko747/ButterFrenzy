using System.Collections.Generic;
using InternalAssets.Scripts.Enemies;
using UnityEngine;

namespace InternalAssets.Scripts.Level
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private Transform startLevelTransform;

        public Vector3 PlayerStartPosition => new(startLevelTransform.position.x,
            startLevelTransform.position.y + 1, startLevelTransform.position.z);
        
        public Transform StartLevelTransform() => startLevelTransform;
    }
}
