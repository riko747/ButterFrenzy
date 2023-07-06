using InternalAssets.Scripts.Services;
using Zenject;

namespace InternalAssets.Scripts.Installers
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelService>().To<LevelService>().FromComponentInHierarchy();
            Container.Bind<IResourcesService>().To<ResourcesService>().FromComponentInHierarchy();
        }
    }
}