using System.Threading.Tasks;
using InternalAssets.Scripts.Player;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies.Traps
{
    public class LandMineTrap : Trap
    {
        private const float ExplosionForce = 2000f;
        private const float ExplosionRadius = 50;

        protected override async void OnCollisionEnter(Collision collision)
        {
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController == null) return;
            
            playerController.PlayerState.PlayerExploded?.Invoke();
            await Explode(collision);
        }

        private async Task Explode(Collision collision)
        {
            var colliders = new Collider[10];
            var numColliders = Physics.OverlapSphereNonAlloc(transform.position, ExplosionRadius, colliders);

            for (var i = 0; i < numColliders; i++)
            {
                var hit = colliders[i];
                var rb = hit.GetComponent<Rigidbody>();

                if (rb == null) continue;

                var landMinePosition = transform.position;
                var explosionDirection = rb.transform.position - landMinePosition;
                explosionDirection.Normalize();

                var randomDirection = Random.insideUnitSphere;

                explosionDirection += randomDirection;
                explosionDirection.Normalize();

                rb.AddExplosionForce(ExplosionForce, landMinePosition, ExplosionRadius);
            }

            await Task.Delay(2000);
            base.OnCollisionEnter(collision);
        }
    }
}
