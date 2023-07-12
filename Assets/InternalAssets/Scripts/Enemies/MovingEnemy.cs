using DG.Tweening;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class MovingEnemy : Enemy
    {
        public override void Move()
        {
            var enemyLocalPosition = transform.localPosition;
            var movementVector = new Vector3(3.5f, enemyLocalPosition.y, enemyLocalPosition.z);
            base.Move();
            AnimationSequence = DOTween.Sequence().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
            AnimationSequence.Append(transform.DOLocalMove(movementVector, 2));
            AnimationSequence.Play();
        }
    }
}
