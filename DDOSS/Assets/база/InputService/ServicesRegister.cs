using UnityEngine;
using VContainer;
using VContainer.Unity;
using база.Economy;
using база.InventorySystem;
using база.InventorySystem.UI;
using база.MOBS.TargetSystem;
using база.PlayerSystem.PlayerECS;
using база.Tests;
using база.WorldBase;

namespace база.InputServices
{
    public sealed class ServicesRegister : LifetimeScope
    {
        public Transform movePointsContainer;
        public Player player;
        public ItemPicker itemPickerPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            Injector.SetResolver(Container);
            
            builder
                .Register<InputService>(Lifetime.Singleton)
                .As<IInputService>()
                .As<ITickable>();
            
            builder
                .Register<Inventory>(Lifetime.Singleton)
                .As<Inventory>()
                .As<ITickable>();

            builder
                .RegisterComponent(itemPickerPrefab)
                .AsSelf();

            builder
                .Register<ItemsDropper>(Lifetime.Singleton)
                .AsSelf();
            
            builder
                .RegisterComponent(player)
                .AsSelf();

            builder
                .RegisterInstance(new EnemiesMovePoints(movePointsContainer.GetComponentsInChildren<Target>()))
                .AsSelf();
            
            builder
                .Register<Wallet>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}