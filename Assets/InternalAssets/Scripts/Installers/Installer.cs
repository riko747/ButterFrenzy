using InternalAssets.Scripts.Player;
using InternalAssets.Scripts.Services;
using Zenject;

namespace InternalAssets.Scripts.Installers
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerPrefsService>().AsSingle();
            Container.BindInterfacesAndSelfTo<BonusService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerManager>().AsSingle();
        }
    }
}