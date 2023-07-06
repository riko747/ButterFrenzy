using InternalAssets.Scripts.Services;
using Zenject;

namespace InternalAssets.Scripts.Installers
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelService>().To<LevelService>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IResourcesService>().To<ResourcesService>().FromComponentInHierarchy().AsSingle();
        }
    }
}