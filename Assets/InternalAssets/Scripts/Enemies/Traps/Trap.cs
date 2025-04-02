using InternalAssets.Scripts.Other;
using InternalAssets.Scripts.Services;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Enemies.Traps
{
    public class Trap : MonoBehaviour
    {
        [Inject] private GameService _gameService;
        [Inject] private IPlayerManager _playerManager;

        protected virtual void OnCollisionEnter(Collision collision)
        {
            _playerManager.OnPlayerExploded?.Invoke();
        }
    }
}
