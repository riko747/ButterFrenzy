using InternalAssets.Scripts.Other;
using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRigidbody;

        private Enums.PlayerState _playerState;

        private const float MovementSpeed = 10f;
        private const float ClampedMinPosition = -1.85f;
        private const float ClampedMaxPosition = 1.85f;

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            Jump();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _playerState == Enums.PlayerState.OnGround)
            {
                playerRigidbody.AddForce(Vector2.up * 20, ForceMode.Impulse);
            }
        }
        
        private void Move()
        {
            var clampedPosition = playerRigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, ClampedMinPosition, ClampedMaxPosition);
            playerRigidbody.position = clampedPosition;
            
            if (_playerState != Enums.PlayerState.OnGround) return;
            
            var moveX = Input.GetAxis("Horizontal");

            var velocity = playerRigidbody.velocity;
            velocity.x = moveX * MovementSpeed;
            velocity.z = MovementSpeed;
            playerRigidbody.velocity = velocity;

            playerRigidbody.AddForce(Physics.gravity, ForceMode.Acceleration);
        }

        private void OnCollisionExit() => _playerState = Enums.PlayerState.InAir;

        private void OnCollisionStay() => _playerState = Enums.PlayerState.OnGround;
    }
}
