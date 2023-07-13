using DG.Tweening;
using InternalAssets.Scripts.Player;
using InternalAssets.Scripts.Services;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [Inject] private IGameService _gameService;

        protected Sequence AnimationSequence;

        protected virtual void Start() => Move();

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerController>())
                _gameService.EndGame(true);
        }

        protected abstract void Move();
    }
}
