using System;
using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRigidbody;
        
        private const float MovementSpeed = 5f;
        private const float PermanentMovementSpeed = 1;
        private const float ClampedMinPosition = -1.85f;
        private const float ClampedMaxPosition = 1.85f;

        private void FixedUpdate()
        {
            var moveX = Input.GetAxis("Horizontal");

            var movement = new Vector3(moveX, 0, PermanentMovementSpeed);
            playerRigidbody.velocity = movement * MovementSpeed;

            var clampedPosition = playerRigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, ClampedMinPosition, ClampedMaxPosition);
            playerRigidbody.position = clampedPosition;
        }
    }
}
