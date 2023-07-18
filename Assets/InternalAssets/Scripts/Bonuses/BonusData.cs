using InternalAssets.Scripts.Other;

namespace InternalAssets.Scripts.Bonuses
{
    public class BonusData
    {
        private int _jumpBonusCount;

        public int GetBonusCount(Enums.BonusType bonusType)
        {
            return bonusType switch
            {
                Enums.BonusType.JumpBonus => _jumpBonusCount,
                _ => 0
            };
        }
        public void AddJumpBonus() => _jumpBonusCount += 1;
        public void DecreaseJumpBonus() => _jumpBonusCount -= 1;

    }
}
