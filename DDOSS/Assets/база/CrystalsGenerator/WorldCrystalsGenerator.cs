using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using база.Crystales;
using база.Tests;
using Random = UnityEngine.Random;

namespace база.CrystalsGenerator
{
    public class WorldCrystalsGenerator : MonoBehaviour
    {
        public List<AreaConfig> areas = new();
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        private void Start()
        {
            foreach (var area in areas)
            {
                StartCoroutine(AreaLogic(area));
            }
        }

        private IEnumerator AreaLogic(AreaConfig area)
        {
            area.SetPoint();
            
            while (enabled)
            {
                foreach (var point in area.Points)
                {
                    point.Destroy();
                    var prefab = area.CrystalsPrefabsList[Random.Range(0, area.CrystalsPrefabsList.Count)];
                    
                    var spawned = _resolver.Instantiate(prefab.gameObject);

                    spawned.GetComponent<CristalMinerAndObject>().SetItem(spawned.GetComponent<WorldCrystal>().item);
                    point.Set(spawned.GetComponent<WorldCrystal>());
                }

                yield return new WaitForSeconds(area.RespawnRate);
            }
        }
    }
}