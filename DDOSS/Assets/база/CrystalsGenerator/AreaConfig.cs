using System;
using System.Collections.Generic;
using UnityEngine;
using база.Crystales;

namespace база.CrystalsGenerator
{
    [Serializable]
    public sealed class AreaConfig
    {
        public float RespawnRate;
        public List<WorldCrystal> CrystalsPrefabsList;
        public Transform AreaSpawnPointsContainer;
        public CrystalPoint[] Points;

        public void SetPoint()
        {
            Points = AreaSpawnPointsContainer.GetComponentsInChildren<CrystalPoint>();
        }
    }
}