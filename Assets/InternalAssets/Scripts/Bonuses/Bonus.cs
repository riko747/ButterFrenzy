using DG.Tweening;
using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        [Inject] protected IBonusService BonusService;
        
        [SerializeField] protected Enums.BonusType bonusType;

        private const int RotationAngle = 360;
        private const int RotationDuration = 2;

        private Sequence _animationSequence;

        public Enums.BonusType BonusType => bonusType;

        private void Start() => Rotate();

        private void Rotate()
        {
            _animationSequence?.Kill();
            _animationSequence = DOTween.Sequence().SetLoops(-1);
            _animationSequence.Append(DOTween
                .To(() => 0f, angle => transform.localRotation = Quaternion.Euler(transform.rotation.x, angle, 0), RotationAngle,
                    RotationDuration)
                .SetEase(Ease.Linear));
            _animationSequence.Play();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _animationSequence?.Kill();
        }
    }
}