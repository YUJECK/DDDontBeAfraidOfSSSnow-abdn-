using UnityEngine;

namespace база.PlayerSystem.PlayerECS
{
    public class DefaultusComponentus : IComponent
    {
        protected Player Master;
        
        public void InitializeMaster(Player master)
        {
            Master = master;
        }

        public virtual void OnAdded()
        {
            if(Master == null)
                Debug.LogError("Master is null");
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnRemoved()
        {
            
        }
    }
}