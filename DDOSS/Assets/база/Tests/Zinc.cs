using UnityEngine;
using база.InventorySystem;
using база.Recyclables;
using база.WorldBase;

namespace база.Tests
{
    [CreateAssetMenu(menuName = "Items/Zinc")]
    public sealed class Zinc : Item, IRecyclable
    {
        public Ruby Ruby;
        
        public Item Recycle()
        {
            Ruby newRuby = Instantiate(Ruby);
            Injector.Inject(newRuby);

            return newRuby;
        }
    }
}