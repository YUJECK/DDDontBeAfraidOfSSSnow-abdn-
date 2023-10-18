using VContainer;
using VContainer.Unity;

namespace база.InputService
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