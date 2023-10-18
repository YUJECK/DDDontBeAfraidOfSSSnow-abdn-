namespace база.Player.PlayerECS
{
    public class DefaultusComponent : IComponent
    {
        protected Player Master;
        
        public void InitializeMaster(Player master)
        {
            Master = master;
        }

        public virtual void OnAdded()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnRemoved()
        {
            
        }
    }
}