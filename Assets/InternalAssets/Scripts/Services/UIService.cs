using System;
using InternalAssets.Scripts.Other;
using InternalAssets.Scripts.UI;

namespace InternalAssets.Scripts.Services
{
    public class UIService : IUIService
    {
        private UIBonusArea _uiBonusArea;

        public Action<Enums.BonusType> OnBonusChange { get; set; }
    }
}
