using System.Threading.Tasks;
using InternalAssets.Scripts.Player;
using UnityEngine;
using Random = System.Random;

namespace InternalAssets.Scripts.Enemies.Traps
{
    public class LandMineTrap : Trap
    {
        private MeshRenderer _trapRenderer;
        private Random _random;

        private void Start()
        {
            _trapRenderer = GetComponent<MeshRenderer>();
        }

        protected override void OnCollisionEnter(Collision collision)
        {
            var playerController = collision.gameObject.GetComponent<Player.Player>();

            if (playerController == null) return;
            
            base.OnCollisionEnter(collision);
            
            _trapRenderer.enabled = false;
            
            Explode(collision);
        }

        private void Explode(Collision touchedCollision)
        {
            var explosionPosition = transform.position;
            var explosionRadius = 50.0f;
            var explosionForce = 50.0f;

            var touchedRigidbody = touchedCollision.collider.GetComponent<Rigidbody>();
            
            if (touchedRigidbody == null) return;
            {
                touchedRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 3.0f, ForceMode.Impulse);
            }
        }
    }
}
