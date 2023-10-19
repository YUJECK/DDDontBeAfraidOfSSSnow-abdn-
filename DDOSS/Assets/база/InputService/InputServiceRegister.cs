using VContainer;
using VContainer.Unity;

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
        }
    }
}