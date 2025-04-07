using System;
using InternalAssets.Scripts.Other;
using Zenject;

namespace InternalAssets.Scripts.Player
{
    public class PlayerManager : IPlayerManager
    {
        public Action OnPlayerExploded { get; set; }
        public Player Player { get; set; }
        
        
        private IGameService _gameService;

        #region Injections

        [Inject]
        private void InjectDependencies(IGameService gameService)
        {
            _gameService = gameService;
        }

        #endregion
        
        public void KillPlayer()
        {
            DisablePlayerController();
            DisablePlayerRotationConstraints();
            _gameService.EndGame(true);
        }
        
        private void DisablePlayerController() => Player.enabled = false;

        public void DisablePlayerRotationConstraints() => Player.GetPlayerRigidbody().freezeRotation = false;
    }
}
