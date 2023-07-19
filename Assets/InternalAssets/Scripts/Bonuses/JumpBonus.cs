using UnityEngine;

namespace InternalAssets.Scripts.Bonuses
{
    public class JumpBonus : Bonus
    {
        protected override void OnTriggerEnter(Collider other)
        {
            BonusService.AddBonus(this);
            Destroy(gameObject);
        }
    }
}
