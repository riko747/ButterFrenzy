using System;

namespace InternalAssets.Scripts.Player
{
    public class PlayerState
    {
        public const float MovementSpeed = 10f;
        public const float ClampedMinPosition = -1.85f;
        public const float ClampedMaxPosition = 1.85f;
        public const float JumpPower = 20;
        
        public Action PlayerExploded;
    }
}
