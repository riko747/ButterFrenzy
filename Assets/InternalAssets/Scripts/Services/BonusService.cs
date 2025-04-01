using InternalAssets.Scripts.Bonuses;
using InternalAssets.Scripts.Other;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class BonusService : IBonusService
    {
        [Inject] private IUIService _uiService;

        public BonusData BonusData { get; private set; }

        public void Initialize()
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
                    _uiService.OnBonusChange?.Invoke(Enums.BonusType.JumpBonus);
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
