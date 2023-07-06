using InternalAssets.Scripts.Services;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Player
{
    public class PlayerData : MonoBehaviour
    {
        [Inject] private ILevelService _levelService;

        public void SetStartPlayerPosition()
        {
            transform.position = new Vector3(_levelService.StartPositionTransform.x,
                _levelService.StartPositionTransform.y, _levelService.StartPositionTransform.z);
        }
    }
}
