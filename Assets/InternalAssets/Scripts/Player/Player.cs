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
        [SerializeField] protected PlayerController playerController;
        
        public PlayerData PlayerData { get; set; }

        #region EventMethods
        private void Awake()
        {
            PlayerData = new PlayerData();
            _playerManager.Player = this;
        }
        private void Start() => _playerManager.OnPlayerExploded += () => StartCoroutine(DisablePlayerDelayed());

        private void OnDestroy() => _playerManager.OnPlayerExploded -= () => StartCoroutine(DisablePlayerDelayed());
        #endregion

        #region EntitySpecificMethods
        public Rigidbody GetPlayerRigidbody() => playerRigidbody;

        private IEnumerator DisablePlayerDelayed()
        {
            _playerManager.DisablePlayerConstraints();
            yield return new WaitForSeconds(2f);
            _playerManager.KillPlayer();
        }
        
        #endregion
    }
}
