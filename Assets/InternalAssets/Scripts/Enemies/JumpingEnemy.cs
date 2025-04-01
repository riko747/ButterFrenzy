using System.Collections;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class JumpingEnemy : Enemy
    { 
        [SerializeField] private Rigidbody enemyRigidbody;

        private const int JumpPower = 5;

        private Vector3 _jumpVector;
        private System.Random _random;
        private int _jumpInterval;
        
        protected override void Start()
        {
            _jumpVector = new Vector3(0, 2, 0);
            _random = new System.Random();
            _jumpInterval = _random.Next(1, 5);
            
            StartCoroutine(JumpCoroutine());
        }

        protected override void Move() => enemyRigidbody.AddForce(_jumpVector * JumpPower, ForceMode.Impulse);

        private IEnumerator JumpCoroutine()
        {
            while (true)
            {
                Move();
                yield return new WaitForSeconds(_jumpInterval);
            }
        }
    }
}