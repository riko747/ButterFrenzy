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
        
        public void KillPlayer()
        {
            DisablePlayerController();
            DisablePlayerConstraints();
            _gameService.EndGame(true);
        }
        
        private void DisablePlayerController() => Player.enabled = false;

        public void DisablePlayerConstraints() => Player.GetPlayerRigidbody().freezeRotation = false;
    }
}
