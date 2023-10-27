using UnityEngine;

namespace база.WorldBase
{
    public class SpawnPoint<TObject> : MonoBehaviour, ISpawnPoint where TObject : MonoBehaviour, IDestroyable
    {
        public bool Free => Current == null; 
        public TObject Current { get; private set; }

        public virtual void Set(TObject toSet)
        {
            Current = toSet;
            toSet.transform.position = transform.position;
            toSet.transform.parent = transform;

            toSet.OnDestroyed += OnObjectDestroyed;
        }

        protected virtual void OnObjectDestroyed()
        {
            
        }

        public virtual void Destroy()
        {
            if (Current != null)
            {
                GameObject.Destroy(Current.gameObject);
                Current = null;    
            }
        }
    }
}