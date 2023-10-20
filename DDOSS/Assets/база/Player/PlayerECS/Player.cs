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
        public Animator Animator { get; private set; }
        
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
            Animator = GetComponent<Animator>();
            InitializeComponents();
        }

        private void Update()
        {
            _componentsContainer.UpdateAll();
        }

        private void InitializeComponents()
        {
            _componentsContainer = new ComponentsContainer(new Dictionary<Type, IComponent>(), this);
            
            _componentsContainer.EnableAutoInject(_resolver);
            
            _componentsContainer.Add<Movement>(new Movement());
            _componentsContainer.Add<Examiner>(new Examiner());
            _componentsContainer.Add<Flipper>(new Flipper(_componentsContainer.Get<Movement>()));
            _componentsContainer.Add<Pointer>(new Pointer());
        }
    }
}