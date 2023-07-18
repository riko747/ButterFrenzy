using InternalAssets.Scripts.Bonuses;
using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class BonusService : MonoBehaviour, IBonusService
    {
        [Inject] private IUIService _uiService;

        public BonusData BonusData { get; private set; }

        private void Awake()
        {
            BonusData = new BonusData();
        }

        public bool HasBonus(Enums.BonusType bonusType)
        {
            return BonusData.GetBonusCount(bonusType) > 0;
        }

        public void AddBonus(Bonus bonus)
        {
            switch (bonus.BonusType)
            {
                case Enums.BonusType.JumpBonus:
                    BonusData.AddJumpBonus();
                    _uiService.OnBonusChange?.Invoke(bonus.BonusType);
                    break;
                default:
                    return;
            }
        }

        public void DecreaseBonus(Enums.BonusType bonusType)
        {
            switch (bonusType)
            {
                case Enums.BonusType.JumpBonus:
                    BonusData.DecreaseJumpBonus();
                    _uiService.OnBonusChange?.Invoke(bonusType);
                    break;
                default:
                    return;
            }
        }
    }
}
