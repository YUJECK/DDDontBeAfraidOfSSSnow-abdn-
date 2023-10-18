namespace база.Player.PlayerECS
{
    public interface IComponent
    {
        void InitializeMaster(Player master);
        void OnAdded();
        void OnUpdate();
        void OnRemoved();
    }
}