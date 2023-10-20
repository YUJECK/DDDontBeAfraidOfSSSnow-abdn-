using UnityEngine;
using база.Player;

namespace база
{
    public class TestPo : MonoBehaviour, IPointable
    {
        public void Point()
        {
            Debug.Log("afafa");
        }
    }
}