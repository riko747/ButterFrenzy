using System;
using InternalAssets.Scripts.Other;
using InternalAssets.Scripts.UI;
using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    public class UIService : MonoBehaviour, IUIService
    {
        [SerializeField] private UIBonusArea uiBonusArea;

        public Action<Enums.BonusType> OnBonusChange { get; set; }

        private void Start()
        {
            OnBonusChange += UpdateBonusArea;
        }

        private void UpdateBonusArea(Enums.BonusType bonusType) => uiBonusArea.UpdateUI(bonusType);

        private void OnDestroy()
        {
            OnBonusChange -= UpdateBonusArea;
        }
    }
}
