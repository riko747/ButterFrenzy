using System.Collections;
using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Inject] private IPlayerManager _playerManager;
        
        [SerializeField] protected Rigidbody playerRigidbody;
        
        public PlayerData PlayerData { get; set; }

        private void Awake()
        {
            PlayerData = new PlayerData();
            _playerManager.Player = this;
        }

        private void Start() => _playerManager.OnPlayerExploded += () => StartCoroutine(DisablePlayerDelayed());

        public Rigidbody GetPlayerRigidbody() => playerRigidbody;

        private void OnDestroy() => _playerManager.OnPlayerExploded -= () => StartCoroutine(DisablePlayerDelayed());

        private IEnumerator DisablePlayerDelayed()
        {
            yield return new WaitForSeconds(2f);
            _playerManager.KillPlayer(this);
        }
    }
}
