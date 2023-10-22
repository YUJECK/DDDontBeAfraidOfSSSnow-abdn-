using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace база.PlayerSystem.PlayerECS
{
    public sealed class ComponentsContainer
    {
        private readonly Dictionary<Type, IComponent> _components;
        private readonly Player _master;
        
        private IObjectResolver _resolver;

        public ComponentsContainer(Dictionary<Type, IComponent> components, Player master)
        {
            _components = components;
            _master = master;
        }

        public void InjectAll(IObjectResolver resolver)
        {
            foreach (var component in _components)
                resolver.Inject(component.Value);
        }

        public void EnableAutoInject(IObjectResolver resolver)
            => _resolver = resolver;
        
        public void DisableAutoInject(IObjectResolver resolver)
            => _resolver = null;

        public void UpdateAll()
        {
            foreach (var component in _components)
                component.Value.OnUpdate();
        }

        public void RemoveAll()
        {
            foreach (var component in _components)
                component.Value.OnRemoved();
        }

        public TComponent Get<TComponent>()
        {
            return (TComponent)_components[typeof(TComponent)];
        }
        
        public void Add<TComponent>(TComponent component, bool replace = false)
            where TComponent : IComponent
        {
            if (component == null)
            {
                Debug.LogError("You tried to add null component");
                return;
            }

            var componentType = typeof(TComponent);
            
            if (!_components.TryAdd(componentType, component) && replace)
            {
                _components[componentType].OnRemoved();
                _components[componentType] = component;
            }
            
            component.InitializeMaster(_master);

            if (_resolver != null)
            {
                _resolver.Inject(component);
            }
            
            component.OnAdded();
        }

        public void Remove<TComponent>()
        {
            var componentType = typeof(TComponent);

            if (_components.ContainsKey(componentType))
            {
                _components.Remove(componentType);
            }
            else
            {
                Debug.LogError($"Component {componentType} wasn't found");    
            }
        }

        public bool Contains<TComponent>()
            where TComponent : IComponent
        {
            return _components.ContainsKey(typeof(TComponent));
        }
    }
}
