using DG.Tweening;
using InternalAssets.Scripts.Other;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class MovingEnemy : Enemy
    {
        [SerializeField] private Enums.EnemyMovementDirection movementDirection;
        [SerializeField] private Ease ease;

        private const int MovementDuration = 2;
        private const float MovementValueX = 3.5f;
        private const float MovementValueZ = 10;
        
        protected override void Move()
        {
            AnimationSequence?.Kill();
            var enemyLocalPosition = transform.localPosition;
            var movementVector = SetMovementVector(enemyLocalPosition);
            AnimationSequence = DOTween.Sequence().SetLoops(-1, LoopType.Yoyo).SetEase(ease);
            AnimationSequence.Append(transform.DOLocalMove(movementVector, MovementDuration));
            AnimationSequence.Play();
        }

        private Vector3 SetMovementVector(Vector3 enemyLocalPosition)
        {
            var movementVector = movementDirection switch
            {
                Enums.EnemyMovementDirection.XDirection => new Vector3(MovementValueX, enemyLocalPosition.y,
                    enemyLocalPosition.z),
                Enums.EnemyMovementDirection.ZDirection => new Vector3(enemyLocalPosition.x, enemyLocalPosition.y,
                    enemyLocalPosition.z + MovementValueZ),
                _ => default
            };
            return movementVector;
        }
    }
}
