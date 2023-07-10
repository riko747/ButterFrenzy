using DG.Tweening;
using UnityEngine;

namespace InternalAssets.Scripts.Enemies
{
    public class RotatingEnemy : Enemy
    {
        public override void Move()
        {
            base.Move();
            AnimationSequence = DOTween.Sequence().SetLoops(-1);
            AnimationSequence.Append(DOTween
                .To(() => 0f, angle => transform.localRotation = Quaternion.Euler(0, angle, 0), 360f, 2f)
                .SetEase(Ease.Linear));
            AnimationSequence.Play();
        }
    }
}
