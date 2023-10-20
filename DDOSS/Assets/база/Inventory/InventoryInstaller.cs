using VContainer;
using VContainer.Unity;

namespace база.InventorySystem
{
    public class InventoryInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<Inventory>(Lifetime.Singleton)
                .As<Inventory>()
                .As<ITickable>();
        }
    }
}
