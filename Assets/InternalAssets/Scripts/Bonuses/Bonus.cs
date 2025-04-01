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
            if (!this) return;
            
            _animationSequence?.Kill();
            _animationSequence = DOTween.Sequence().SetLoops(-1);
            _animationSequence.Append(DOTween
                .To(() => 0f, angle => transform.localRotation = Quaternion.Euler(0, angle, 0), RotationAngle,
                    RotationDuration)
                .SetEase(Ease.Linear));
            _animationSequence.Play();
        }

        protected abstract void OnTriggerEnter(Collider other);
    }
}