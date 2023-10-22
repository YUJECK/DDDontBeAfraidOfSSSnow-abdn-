using UnityEngine;
using база.PlayerSystem;

namespace база.Tests
{
    public class PointerBloom : MonoBehaviour, IPointable
    {
        public SpriteRenderer spriteRenderer;
        
        private void Awake()
        {
            if(spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Point()
        {
            var color = spriteRenderer.color;
            
            color = new Color(color.a, color.b,color.maxColorComponent, 0.5f);
            spriteRenderer.color = color;
        }

        public void Unpoint()
        {
            spriteRenderer.color = Color.white;            
        }
    }
}