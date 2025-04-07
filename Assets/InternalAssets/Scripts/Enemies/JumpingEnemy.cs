using System;
using Cysharp.Threading.Tasks;
using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace InternalAssets.Scripts.Enemies
{
    public class JumpingEnemy : Enemy
    {
        [Inject] IPlayerManager _playerManager;
        
        [SerializeField] private Rigidbody enemyRigidbody;
        [SerializeField] private Animation jumpingAnimation;

        private const int JumpForce = 5;

        private int _jumpInterval;
        private Random _random;
        
        protected override void Start()
        {
            JumpTask().Forget();
            _random = new Random();
            _jumpInterval = _random.Next(1, 3);
        }

        protected override void Move()
        {
            var upVector = transform.up.normalized;
            var forwardToPlayerVector = (_playerManager.Player.transform.position - transform.position).normalized;
            var resultVector = upVector + forwardToPlayerVector;
            enemyRigidbody.AddForce(resultVector * JumpForce, ForceMode.Impulse);
            jumpingAnimation.Play("Jump");
        }

        private async UniTask JumpTask()
        {
            while (this)
            {
                Move();
                transform.LookAt(_playerManager.Player.transform.position);
                await UniTask.Delay(TimeSpan.FromSeconds(_jumpInterval));
            }
        }
    }
}