using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace база.Player.PlayerECS
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D { get; private set; }
        
        private ComponentsContainer _componentsContainer;
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
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