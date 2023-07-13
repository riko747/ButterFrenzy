using DG.Tweening;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class MovingEnemy : Enemy
    {
        protected override void Move()
        {
            AnimationSequence?.Kill();
            var enemyLocalPosition = transform.localPosition;
            var movementVector = new Vector3(3.5f, enemyLocalPosition.y, enemyLocalPosition.z);
            AnimationSequence = DOTween.Sequence().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
            AnimationSequence.Append(transform.DOLocalMove(movementVector, 2));
            AnimationSequence.Play();
        }
    }
}
