using VContainer;
using VContainer.Unity;
using база.InventorySystem;

namespace база.InputServices
{
    public sealed class InputServiceRegister : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<InputService>(Lifetime.Singleton)
                .As<IInputService>()
                .As<ITickable>();
            
            builder
                .Register<Inventory>(Lifetime.Singleton)
                .As<Inventory>()
                .As<ITickable>();
        }
    }
}