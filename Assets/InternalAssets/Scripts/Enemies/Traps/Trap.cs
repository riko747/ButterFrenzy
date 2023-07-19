using InternalAssets.Scripts.Other;
using InternalAssets.Scripts.Player;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Enemies.Traps
{
    public class Trap : MonoBehaviour
    {
        [Inject] private IGameService _gameService;

        protected virtual void OnCollisionEnter(Collision collision)
        {
            _gameService.EndGame(true);
        }
    }
}
