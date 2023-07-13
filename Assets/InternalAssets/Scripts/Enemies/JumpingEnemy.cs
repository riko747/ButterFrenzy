using System.Collections;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class JumpingEnemy : Enemy
    { 
        [SerializeField] private Rigidbody enemyRigidbody;

        protected override void Start() => StartCoroutine(JumpCoroutine());

        protected override void Move()
        {
            var jumpVector = new Vector3(0, 2, 0);
            enemyRigidbody.AddForce(jumpVector * 5, ForceMode.Impulse);
        }

        private IEnumerator JumpCoroutine()
        {
            while (true)
            {
                Move();
                yield return new WaitForSeconds(2);
            }
        }
    }
}