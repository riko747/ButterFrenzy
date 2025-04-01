using InternalAssets.Scripts.Other;
using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    public class PlayerPrefsService : IPlayerPrefsService
    {
        public void SetPlayerPrefsValue(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
    }
}
