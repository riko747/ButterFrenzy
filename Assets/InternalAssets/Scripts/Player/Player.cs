using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected Rigidbody playerRigidbody;

        private PlayerManager PlayerManager { get; set; }
        public PlayerState PlayerState { get; set; }

        private void Awake()
        {
            PlayerManager = new PlayerManager();
            PlayerState = new PlayerState();
        }

        private void Start() => PlayerState.PlayerExploded += () => PlayerManager.DisablePlayer(this);

        public Rigidbody GetPlayerRigidbody() => playerRigidbody;
        
        private void OnDestroy() => PlayerState.PlayerExploded -= () => PlayerManager.DisablePlayer(this);
    }
}
