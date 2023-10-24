using база.CrystalsGenerator;
using база.WorldBase;

namespace база.Crystales
{
    public sealed class CrystalPoint : SpawnPoint<WorldCrystal>
    {
        public override void Set(WorldCrystal toSet)
        {
            base.Set(toSet);
            
            CrystalsModel.Add(Current);
        }

        protected override void OnObjectDestroyed()
        {
            CrystalsModel.Remove(Current);
        }
    }
}