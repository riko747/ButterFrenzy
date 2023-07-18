using UnityEngine;

namespace InternalAssets.Scripts.Bonuses
{
    public class JumpBonus : Bonus
    {
        protected override void OnTriggerEnter(Collider other)
        {
            _bonusService.AddBonus(this);
            Destroy(gameObject);
        }
    }
}
