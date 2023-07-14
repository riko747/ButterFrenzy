using InternalAssets.Scripts.Other;
using InternalAssets.Scripts.Player;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Level
{
    public class FinishLine : MonoBehaviour
    {
        [Inject] private IGameService _gameService;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerController>())
                _gameService.EndGame(false);
        }
    }
}
