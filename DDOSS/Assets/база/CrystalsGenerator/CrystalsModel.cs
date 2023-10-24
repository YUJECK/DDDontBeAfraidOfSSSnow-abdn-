using System.Collections.Generic;
using база.Crystales;

namespace база.CrystalsGenerator
{
    public static class CrystalsModel
    {
        public static int CrystalsCount { get; private set; }
        public static WorldCrystal[] CrystalsList => Crystals.ToArray(); 

        private static readonly List<WorldCrystal> Crystals = new();

        public static void Add(WorldCrystal crystal)
        {
            if(crystal == null) 
                return;
            
            Crystals.Add(crystal);
            CrystalsCount += 1;
        }
        public static void Remove(WorldCrystal crystal)
        {
            if(crystal == null) 
                return;
            
            Crystals.Remove(crystal);
            CrystalsCount -= 1;
        }
    }
}