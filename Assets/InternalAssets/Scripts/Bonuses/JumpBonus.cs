using UnityEngine;

namespace InternalAssets.Scripts.Bonuses
{
    public class JumpBonus : Bonus
    {

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.GetComponent<Player.Player>()) return;
            
            BonusService.AddBonus(this);
            StopAllAnimations();
            Destroy(gameObject);
        }
    }
}
