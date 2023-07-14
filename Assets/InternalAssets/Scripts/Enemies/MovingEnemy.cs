using DG.Tweening;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class MovingEnemy : Enemy
    {
        private const float MovementValueX = 3.5f;
        private const int MovementDuration = 2;
        
        protected override void Move()
        {
            AnimationSequence?.Kill();
            var enemyLocalPosition = transform.localPosition;
            var movementVector = new Vector3(MovementValueX, enemyLocalPosition.y, enemyLocalPosition.z);
            AnimationSequence = DOTween.Sequence().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
            AnimationSequence.Append(transform.DOLocalMove(movementVector, MovementDuration));
            AnimationSequence.Play();
        }
    }
}
