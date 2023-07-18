using InternalAssets.Scripts.Other;
using TMPro;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.UI
{
    public class UIBonusArea : MonoBehaviour
    {
        [Inject] private IBonusService _bonusService;
        
        [SerializeField] private TextMeshProUGUI jumpBonusValue;

        public void UpdateUI(Enums.BonusType bonusType)
        {
            switch (bonusType)
            {
                case Enums.BonusType.JumpBonus:
                    jumpBonusValue.text = _bonusService.BonusData.GetBonusCount(Enums.BonusType.JumpBonus).ToString();
                    break;
                default:
                    return;
            }
        }
    }
}
