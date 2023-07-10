using DG.Tweening;
using InternalAssets.Scripts.Player;
using InternalAssets.Scripts.Services;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [Inject] private IGameService _gameService;

        protected Sequence AnimationSequence;

        private void Start() => Move();

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerController>())
                _gameService.EndGame(true);
        }

        public virtual void Move()
        {
            AnimationSequence?.Kill();
            AnimationSequence = DOTween.Sequence();
        }
    }
}
