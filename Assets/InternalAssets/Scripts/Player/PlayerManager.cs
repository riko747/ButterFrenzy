using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class PlayerManager
    {
        public void DisablePlayer(Player playerController)
        {
            DisablePlayerController(playerController);
            DisablePlayerConstraints(playerController.GetPlayerRigidbody());
        }
        private void DisablePlayerController(Behaviour playerController) => playerController.enabled = false;

        private void DisablePlayerConstraints(Rigidbody playerRigidbody) => playerRigidbody.freezeRotation = false;
    }
}
