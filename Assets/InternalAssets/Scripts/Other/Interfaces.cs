using InternalAssets.Scripts.Bonuses;
using InternalAssets.Scripts.Level;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Other
{
    internal interface IGameService
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
        public void ActivateBonus(Bonus bonus);
    }
}
