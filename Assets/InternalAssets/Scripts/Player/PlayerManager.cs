using System;
using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Player
{
    public class PlayerManager : IPlayerManager
    {
        public Action OnPlayerExploded { get; set; }
        public Player Player { get; set; }
        
        
        private IGameService _gameService;
        
        [Inject]
        private void InjectDependencies(IGameService gameService)
        {
            _gameService = gameService;
        }
        
        public void KillPlayer(Player player)
        {
            DisablePlayerController(player);
            DisablePlayerConstraints(player.GetPlayerRigidbody());
            _gameService.EndGame(true);
        }
        
        private void DisablePlayerController(Behaviour playerController) => playerController.enabled = false;

        private void DisablePlayerConstraints(Rigidbody playerRigidbody) => playerRigidbody.freezeRotation = false;
    }
}
