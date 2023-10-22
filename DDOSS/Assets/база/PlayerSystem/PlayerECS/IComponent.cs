namespace база.PlayerSystem.PlayerECS
{
    public interface IComponent
    {
        void InitializeMaster(Player master);
        void OnAdded();
        void OnUpdate();
        void OnRemoved();
    }
}