using System;
using Cinemachine;
using InternalAssets.Scripts.Bonuses;
using InternalAssets.Scripts.Level;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Other
{
    #region Services
    public interface IGameService
    {
        public void EndGame(bool gameOver);
        public IInstantiator Instantiator { get; }
    }
    internal interface ILevelService
    {
        LevelData LoadLevel(int index);
        int CurrentLevel { get; set; }
    }
    internal interface IPlayerPrefsService
    {
        public void SetPlayerPrefsValue(string key, int value);
    }
    internal interface IResourcesService
    {
        bool IsLevelExists(int index);
        GameObject LoadLevel(int index);
        GameObject LoadPlayer();
    }
    public interface IBonusService
    {
        BonusData BonusData { get; }
        bool HasBonus(Enums.BonusType bonusType);
        public void AddBonus(Bonus bonus);
        void DecreaseBonus(Enums.BonusType bonusType);
    }
    public interface IUIService
    {
        Action<Enums.BonusType> OnBonusChange { get; set; }
    }

    public interface IPlayerManager
    {
        public Player.Player Player { get; set; }
        public Action OnPlayerExploded { get; set; }
        public void KillPlayer();
        public void DisablePlayerConstraints();
    }
    
    #endregion
}
