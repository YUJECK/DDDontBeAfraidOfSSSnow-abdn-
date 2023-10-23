using System.Collections.Generic;
using UnityEngine;

namespace база.MOBS.TargetSystem
{
    public class Target : MonoBehaviour
    {
        public readonly List<ITargetable> CurrentTargetables = new();

        public virtual void OnTargeted(ITargetable targetable)
        {
            CurrentTargetables.Add(targetable);
        }

        public virtual void OnUnTargeted(ITargetable targetable)
        {
            CurrentTargetables.Remove(targetable);   
        }
    }
}