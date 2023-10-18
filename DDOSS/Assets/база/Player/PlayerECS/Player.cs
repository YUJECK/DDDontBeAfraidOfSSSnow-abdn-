using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace база.Player.PlayerECS
{
    public sealed class Player : MonoBehaviour
    {
        private ComponentsContainer _componentsContainer;
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        private void Awake()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _componentsContainer = new ComponentsContainer(new Dictionary<Type, IComponent>(), this);
            _componentsContainer.Add<Movement>(new Movement());

            _componentsContainer.InjectAll(_resolver);
        }
    }
}