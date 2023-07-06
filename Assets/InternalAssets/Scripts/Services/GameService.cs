using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Services
{
    public class GameService : MonoBehaviour
    {
        [Inject] private ILevelService _levelService;

        private void Start() => StartGame();

        private void StartGame()
        {
            _levelService.LoadLevel(PlayerPrefs.HasKey(Constants.LastLevel)
                ? PlayerPrefs.GetInt(Constants.LastLevel)
                : 0);
        }
    }
}
