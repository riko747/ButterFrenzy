using UnityEngine;

namespace InternalAssets.Scripts.Services
{
    internal interface IPlayerPrefsService
    {
        public void SetPlayerPrefsValue(string key, int value);
    }
    public class PlayerPrefsService : MonoBehaviour, IPlayerPrefsService
    {
        public void SetPlayerPrefsValue(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
    }
}
